using System;
using System.Threading;
using System.Timers;
namespace 实验
{
    class Program
    {
        public static int count = 0;
        //指定在线程引发时你要作什么
        public static void OnTimedEvent(object source,ElapsedEventArgs e)
        {
            Console.WriteLine("时间为{0}秒", count++);
        }
        public static void Main(string[] args)
        {
            //创建一个新的Timer实例，并设置时间间隔为1秒钟
            System.Timers.Timer aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //仅在第一个时间间隔引发线程
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Console.WriteLine("计时开始，按\'q\'结束计时！");
            while (Console.Read() != 'q') ;
        }
    }
}
