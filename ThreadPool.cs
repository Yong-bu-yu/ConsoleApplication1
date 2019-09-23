using System;
using System.Threading;
namespace 实验
{
    class Program
    {
        public class PoolingDemo
        {
            public void SimpleThreadFunc(Object obj)
            {
                Console.Write("Today is {0}:", obj);
                //输出当前的日期，和正在运行的线程的名称
                Console.WriteLine("Thread ID {0} in SimpleThreadFunc()",/*获取当前运行线程的ID*/AppDomain.GetCurrentThreadId().ToString());
                int nWorkerThreads;
                int nIOThreads;
                //报告线程池中剩余的线程数
                ThreadPool.GetAvailableThreads(out nWorkerThreads, out nIOThreads);
                Console.WriteLine("Available worker threads:{0}", nWorkerThreads.ToString());
                Thread.Sleep(1000);
            }
        }
        public static void Main(string[] args)
        {
            //创建一个线程池
            PoolingDemo demo = new PoolingDemo();
            String strToday = DateTime.Today.ToShortDateString();
            //对函数进行5次调用
            for (int i = 0; i < 51; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(demo.SimpleThreadFunc), strToday);
            }
            Thread.Sleep(10000);
        }
    }
}
