//����������-��������ģ�͡�
//�����ߴ������߻����򻺳��Ͷ�Ų�Ʒ�������ߴӻ�����ȡ����Ʒ����˽�˻���
//�������ʱ��������Ҫ�ȴ�������ؿ�ʱ��������Ҫ�ȴ�
//����Ʒȫ��Ͷ������ұ�ȫ��ȡ�ߡ�ʱ�������
//��ȡ�����һ����Ʒ�һ�����������߻���ȫ����ա���Ϊ����Ʒȫ��Ͷ�������ȫ����ȡ�ߡ�
//���ݽṹ��STL����
#pragma once
#include<iostream>
#include<condition_variable>//��������
#include<mutex>//����
#include<queue>
#include<thread>//�߳�
#include<vector>
#include<future>//�첽����
#include<functional>
using namespace std;
#define BUFFER_SIZE 100;
#define PRODUCER_STORE_SIZE 100;


//��дcv_status
enum cv_status{ timeout = false, no_timeout = true };
class Asynchronous
{
public:
	//�����������ǿգ����������̵߳ȴ������������߳�֪ͨ
	condition_variable notEmpty;
	//�������������������������̵߳ȴ������������߳�֪ͨ
	condition_variable notFull;
	//ȫ�ֻ�����
	mutex MyMutex;
	//��ǰ�����Ʒ����
	int CurrentAmount;
	//ֹͣ��־
	bool Stop;
	Asynchronous() :CurrentAmount(0), Stop(false){}
	~Asynchronous(){}
};
template<class T>
class ThreadVec :public Asynchronous
{
public:
	//�����߻���
	queue<T>ProducerStore;
	//�����߻���
	queue<T>ConsumerStore;
	//�����
	queue<T>buffer;
	//�������߳���
	vector<future<void>>SyncProducerPool;
	//�������߳���
	vector<future<void>>SyncConsumerPool;
	//���������
	int BufferSize;
	//��Ʒ����
	int ProducerStoreSize;
	//���һ����Ʒ(δβ��ʶ)
	T endFlag;
	//��ʶ���һ����Ʒ
	T SetEndFlag();
	//�̳й��죬ʹ��Asynchronous����̳еĳ�Ա����
	using Asynchronous::Asynchronous;
	//���캯������ʼ����������С����ʼ�������߻��ִ�С����ǰ��������Ʒ����Ϊ0��ֹͣ��־false
	ThreadVec() :BufferSize(BUFFER_SIZE), ProducerStoreSize(PRODUCER_STORE_SIZE)
	{
		for (int i = 1; i < ProducerStoreSize; i++)
		{
			ProducerStore.push(std::move(i));
			endFlag = std::move(SetEndFlag());
		}
	}
	//������������ӡ���������Ϣ������ĩβ��ʶ��ֹͣ��־
	~ThreadVec()
	{
		this_thread::sleep_for(chrono::seconds(2));
		cout << "�����ֿ߲��ڲ�Ʒ����Ϊ��\t" << ProducerStore.size() << endl;
		cout << "�����ֿ߲��ڲ�Ʒ����Ϊ��\t" << ConsumerStore.size() << endl;
		cout << "�������ڲ�Ʒ����Ϊ��\t\t" << CurrentAmount << endl;
		cout << "���һ����ƷΪ��\t\t" << endFlag << endl;
		endFlag = T();
		Stop = false;
	}
	//�����ߺ���
	void Consumer();
	//�����ߺ���
	void Producer();
	//��������
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
		//�ȴ������߽���ƷͶ�ŵ������
		this_thread::sleep_for(std::chrono::milliseconds(50));
		unique_lock<mutex>locker(MyMutex);
		//Ϊ����ǰ����ز�Ʒ��Ϊ0 ���� ��δ�ӵ�ֹ֪ͣͨ���ȴ�2�룬��������������true����ʱ�򷵻�false
		auto timeFlag_notEmpty = notEmpty.wait_for((locker), std::chrono::microseconds(2000), [=]{return CurrentAmount != 0 || Stop; });
		//��ʱ��ӵ�ֹ֪ͣͨ
		if (timeFlag_notEmpty == timeout)
		{
			cout << "��Ʒȫ����ȡ�ߣ�������" << this_thread::get_id() << "��׼���˳�\n";
			//����ֹ֪ͣͨ
			Stop = true;
		}
		//����δ�ӵ�ֹ֪ͣͨ
		if (!Stop)
		{
			T temp = std::move(buffer.front());
			cout << "�����ߴӻ����ȡ����Ʒ" << temp << endl;
			buffer.pop();
			//����ص�ǰ��Ʒ����-1
			CurrentAmount -= 1;
			cout << "������" << this_thread::get_id() << "��ȡ�߲�Ʒ" << temp << "������������˽�˲ֿ�.\n";
			//���������߻���
			ConsumerStore.push(temp);
			//���ȡ���������һ����Ʒ��Ӧֹͣ
			if (temp == endFlag)
			{
				//����ֹ֪ͣͨ
				Stop = true;
			}
		}
		//֪ͨ������Ͷ�Ų�Ʒ
		notFull.notify_one();
	}
	cout << "������" << this_thread::get_id() << "���߳��˳�\n";
}
template<class T>
void ThreadVec<T>::Producer()
{
	while (ProducerStore.size())
	{
		unique_lock<mutex>locker(MyMutex);
		//Ϊ����������ǰ��Ʒ�������ڻ�������ޡ��ȴ�3�룬�����򷵻�true����ʱ�򷵻�false
		auto timeFlag_notFull = notFull.wait_for(locker, std::chrono::seconds(3), [=]{return CurrentAmount < BufferSize; });
		//��ʱ
		while (timeFlag_notFull == timeout)
		{
			//֪ͨ������ȡ����Ʒ
			notEmpty.notify_one();
			//����Ϊ������ص�ǰ��Ʒ�������ڻ�������ޡ��ȴ�3��
			timeFlag_notFull = notFull.wait_for(locker, std::chrono::seconds(3), [=]{return CurrentAmount < BufferSize; });
		}
		T temp = std::move(ProducerStore.front());
		cout << "�����ߴӻ����������" << temp << endl;
		ProducerStore.pop();
		cout << "�������򻺳����Ͷ�Ż���\n";
		buffer.push(temp);
		//��ǰ����ز�Ʒ����+1
		CurrentAmount += 1;
		//֪ͨ������ȡ����Ʒ
		notEmpty.notify_one();
	}
}
template<class T>
void ThreadVec<T>::launch()
{
	//�����߳���������
	SyncProducerPool.push_back(async(std::launch::async, [&]{return Producer(); }));
	SyncConsumerPool.push_back(async(std::launch::async, [&]{return Consumer(); }));
	SyncConsumerPool.push_back(async(std::launch::async, [&]{return Consumer(); }));
	SyncConsumerPool.push_back(async(std::launch::async, [&]{return Consumer(); }));

	auto pProducer = SyncProducerPool.begin();
	auto pConsumer = SyncConsumerPool.begin();
	//�ȴ������̷߳���
	for (; pProducer != SyncProducerPool.end() && pConsumer != SyncConsumerPool.end(); ++pProducer, ++pConsumer)
	{
		(*pProducer).get();
		(*pConsumer).get();
	}
}