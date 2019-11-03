//“单生产者-多消费者模型”
//生产者从生产者货仓向缓冲池投放产品，消费者从缓冲区取出产品放入私人货仓
//缓冲池满时生产者需要等待，缓冲池空时消费者需要等待
//“产品全部投放完毕且被全部取走”时程序结束
//“取走最后一件产品且缓冲池与生产者货仓全部清空”视为“产品全部投放完毕且全部被取走”
//数据结构：STL队列
#pragma once
#include<iostream>
#include<condition_variable>//条件变量
#include<mutex>//互斥
#include<queue>
#include<thread>//线程
#include<vector>
#include<future>//异步操作
#include<functional>
using namespace std;
#define BUFFER_SIZE 100;
#define PRODUCER_STORE_SIZE 100;


//重写cv_status
enum cv_status{ timeout = false, no_timeout = true };
class Asynchronous
{
public:
	//条件变量：非空，在消费者线程等待，在生产者线程通知
	condition_variable notEmpty;
	//条件变量：不满，在生产者线程等待，在消费者线程通知
	condition_variable notFull;
	//全局互斥量
	mutex MyMutex;
	//当前缓冲产品数量
	int CurrentAmount;
	//停止标志
	bool Stop;
	Asynchronous() :CurrentAmount(0), Stop(false){}
	~Asynchronous(){}
};
template<class T>
class ThreadVec :public Asynchronous
{
public:
	//生产者货仓
	queue<T>ProducerStore;
	//消费者货仓
	queue<T>ConsumerStore;
	//缓冲池
	queue<T>buffer;
	//生产者线程区
	vector<future<void>>SyncProducerPool;
	//消费者线程区
	vector<future<void>>SyncConsumerPool;
	//缓冲池容限
	int BufferSize;
	//产品总数
	int ProducerStoreSize;
	//最后一件产品(未尾标识)
	T endFlag;
	//标识最后一件产品
	T SetEndFlag();
	//继承构造，使用Asynchronous构造继承的成员变量
	using Asynchronous::Asynchronous;
	//构造函数：初始化缓冲区大小，初始化生产者货仓大小，当前缓冲区产品数量为0，停止标志false
	ThreadVec() :BufferSize(BUFFER_SIZE), ProducerStoreSize(PRODUCER_STORE_SIZE)
	{
		for (int i = 1; i < ProducerStoreSize; i++)
		{
			ProducerStore.push(std::move(i));
			endFlag = std::move(SetEndFlag());
		}
	}
	//析构函数：打印程序结束信息，重置末尾标识与停止标志
	~ThreadVec()
	{
		this_thread::sleep_for(chrono::seconds(2));
		cout << "生产者仓库内产品数量为：\t" << ProducerStore.size() << endl;
		cout << "消费者仓库内产品数量为：\t" << ConsumerStore.size() << endl;
		cout << "缓冲区内产品数量为：\t\t" << CurrentAmount << endl;
		cout << "最后一件产品为：\t\t" << endFlag << endl;
		endFlag = T();
		Stop = false;
	}
	//消费者函数
	void Consumer();
	//生产者函数
	void Producer();
	//启动函数
	void launch();
};
template<class T>
T ThreadVec<T>::SetEndFlag()
{
	return ProducerStore.back();
}
template<class T>
void ThreadVec<T>::Consumer()
{
	while (ConsumerStore.size()<ProducerStoreSize&&!Stop)
	{
		//等待生产者将产品投放到缓冲池
		this_thread::sleep_for(std::chrono::milliseconds(50));
		unique_lock<mutex>locker(MyMutex);
		//为“当前缓冲池产品不为0 或者 尚未接到停止通知”等待2秒，满足则立即返回true，超时则返回false
		auto timeFlag_notEmpty = notEmpty.wait_for((locker), std::chrono::microseconds(2000), [=]{return CurrentAmount != 0 || Stop; });
		//超时或接到停止通知
		if (timeFlag_notEmpty == timeout)
		{
			cout << "产品全部被取走，消费者" << this_thread::get_id() << "号准备退出\n";
			//发布停止通知
			Stop = true;
		}
		//若尚未接到停止通知
		if (!Stop)
		{
			T temp = std::move(buffer.front());
			cout << "消费者从缓冲池取出产品" << temp << endl;
			buffer.pop();
			//缓冲池当前产品数量-1
			CurrentAmount -= 1;
			cout << "消费者" << this_thread::get_id() << "号取走产品" << temp << "并放入消费者私人仓库.\n";
			//放入消费者货仓
			ConsumerStore.push(temp);
			//如果取出的是最后一件产品，应停止
			if (temp == endFlag)
			{
				//发布停止通知
				Stop = true;
			}
		}
		//通知生产者投放产品
		notFull.notify_one();
	}
	cout << "消费者" << this_thread::get_id() << "号线程退出\n";
}
template<class T>
void ThreadVec<T>::Producer()
{
	while (ProducerStore.size())
	{
		unique_lock<mutex>locker(MyMutex);
		//为“缓冲区当前产品数量少于缓冲池容限”等待3秒，满足则返回true，超时则返回false
		auto timeFlag_notFull = notFull.wait_for(locker, std::chrono::seconds(3), [=]{return CurrentAmount < BufferSize; });
		//超时
		while (timeFlag_notFull == timeout)
		{
			//通知消费者取出产品
			notEmpty.notify_one();
			//重新为“缓冲池当前产品数量少于缓冲池容限”等待3秒
			timeFlag_notFull = notFull.wait_for(locker, std::chrono::seconds(3), [=]{return CurrentAmount < BufferSize; });
		}
		T temp = std::move(ProducerStore.front());
		cout << "生产者从货仓中提货：" << temp << endl;
		ProducerStore.pop();
		cout << "生产者向缓冲池中投放货物\n";
		buffer.push(temp);
		//当前缓冲池产品数量+1
		CurrentAmount += 1;
		//通知消费者取出产品
		notEmpty.notify_one();
	}
}
template<class T>
void ThreadVec<T>::launch()
{
	//所有线程立即启动
	SyncProducerPool.push_back(async(std::launch::async, [&]{return Producer(); }));
	SyncConsumerPool.push_back(async(std::launch::async, [&]{return Consumer(); }));
	SyncConsumerPool.push_back(async(std::launch::async, [&]{return Consumer(); }));
	SyncConsumerPool.push_back(async(std::launch::async, [&]{return Consumer(); }));

	auto pProducer = SyncProducerPool.begin();
	auto pConsumer = SyncConsumerPool.begin();
	//等待所有线程返回
	for (; pProducer != SyncProducerPool.end() && pConsumer != SyncConsumerPool.end(); ++pProducer, ++pConsumer)
	{
		(*pProducer).get();
		(*pConsumer).get();
	}
}