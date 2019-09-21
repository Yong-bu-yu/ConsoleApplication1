using System;
using System.Collections;
using System.Threading;
namespace 实验
{
    class Program
    {
        class MutexDemo 
        { 
            private Mutex mutex;
            public MutexDemo()
            {
                mutex = new Mutex();
            }
             //定义一个线程运行次数的计数器
            public void Increment()
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + ":value is {0}", i);
                    Thread.Sleep(6);
                }
            }
        }
        public static void Main(string[] args)
        {
            MutexDemo demo = new MutexDemo();
            //创建一个inc，并使之与线程计数器相联系
            Thread inc = new Thread(new ThreadStart(demo.Increment));
            inc.Name = "Increment one";
            Thread inc2 = new Thread(new ThreadStart(demo.Increment));
            inc2.Name = "Increment two";
            inc.Start();
            inc2.Start();
        }
    }
}
