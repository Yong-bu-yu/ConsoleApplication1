using System;
using System.Threading;
namespace 实验
{
    class Program
    {
        public class ThreadWork
        {
            public static void DoWork()
            {
                //在for结构中输出线程运行的次数
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Working thread...重新运行第{0}次", i);
                    Thread.Sleep(100);
                }
            }
        }
        public static void Main(string[] args)
        {
            //创建一个线程代理实例
            ThreadStart myThreadDelegate = new ThreadStart(ThreadWork.DoWork);
            //创建一个线程实例与myThreadDelegate相绑定
            Thread myThread = new Thread(myThreadDelegate);
            myThread.Start();
            //在for循环中输出线程睡眠的次数
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("In main.线程已经睡眠");
                Thread.Sleep(100);
            }
        }
    }
}
