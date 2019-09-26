using System;
using System.Threading;
namespace 实验
{
    class Program
    {
        private static bool TickNext = true;
        private static void TickTock(object state)
        {
            Console.WriteLine(TickNext ? "Tick" : "Tock");
            if(Console.Read()!='\r')//本人添加
            TickNext = !TickNext;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to terminate...");
            //创建一个TimerCallback回调实例
            TimerCallback callback = new TimerCallback(TickTock);
            //创建一个Timer实例
            Timer timer = new Timer(callback, null, 10000, 10000);
            callback.Invoke(timer);//本人添加
            Console.WriteLine();
        }
    }
}
