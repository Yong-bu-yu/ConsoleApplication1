using System;
using System.Threading;
using System.Timers;
namespace 实验
{
    class Program
    {
        public class MyParentThread
        {
            //定义父线程
            //创建3个AutoResetEvent对象
            AutoResetEvent event1 = new AutoResetEvent(false);
            AutoResetEvent event2 = new AutoResetEvent(false);
            AutoResetEvent event3 = new AutoResetEvent(false);
            public void Use3ChildThread()
            {
                //父线程启动了3个子线程
                Thread t1 = new Thread(new ThreadStart(Thread1));
                Thread t2 = new Thread(new ThreadStart(Thread2));
                Thread t3 = new Thread(new ThreadStart(Thread3));
                AutoResetEvent[] EventsInProgress = new AutoResetEvent[3] { event1, event2, event3 };
                t1.Start();
                t2.Start();
                t3.Start();
                //使用WaitHandle.WaitAny()等待任一个子线程给事件做标记
                WaitHandle.WaitAny(EventsInProgress);
            }
            void Thread1()
            {
                Console.WriteLine("Thread1 will sleep for 1 second");
                Thread.Sleep(1000);
                event1.Set();//调用方法set作标记
            }
            void Thread2()
            {
                Console.WriteLine("Thread2 will sleep for 2 second");
                Thread.Sleep(2000);
                event2.Set();
            }
            void Thread3()
            {
                Console.WriteLine("Thread3 will sleep for 3 second");
                Thread.Sleep(3000);
                event3.Set();
            }
        }
        public static void Main(string[] args)
        {
            MyParentThread a = new MyParentThread();
            a.Use3ChildThread();
        }
    }
}
