using System;
using System.Collections;
using System.Threading;
namespace 实验
{
    class Program
    {
        class MonitorDemo
        {
            //定义队列
            Queue queue;
            public MonitorDemo()
            {
                queue = new Queue();
            }
            //定义添加项目方法
            public void AddItem()
            {
                for (int i = 0; i < 6; i++)
                {
                    //在队列上加锁
                    lock (queue)
                    {
                        //入队操作
                        queue.Enqueue("queue item");
                        Console.WriteLine("Queue has {0} items", queue.Count);
                        Monitor.Pulse(queue);
                    }
                }
            }
            //定义删除队列元素的方法
            public void RemoveItem()
            {
                for (int i = 0; i < 4; i++)
                {
                    //获取队列锁
                    Monitor.Enter(queue);
                    if (queue.Count < 4)//如果队列为空，等待
                        Monitor.Wait(queue);
                    //队列不空，就删除队列元素
                    queue.Dequeue();
                    Console.WriteLine("Queue has {0} items", queue.Count);
                    Monitor.Exit(queue);
                }
            }
        }
        public static void Main(string[] args)
        {
            MonitorDemo demo = new MonitorDemo();
            //创建一个添加项目到队列线程
            Thread addThread = new Thread(new ThreadStart(demo.AddItem));
            //修改addThread的运行优先级
            addThread.Priority = ThreadPriority.BelowNormal;
            //创建一个删除项目线程
            Thread removeThread = new Thread(new ThreadStart(demo.RemoveItem));
            //启动添加项目线程
            addThread.Start();
            //启动删除项目线程
            removeThread.Start();
        }
    }
}
