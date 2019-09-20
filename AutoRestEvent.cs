using System;
using System.Threading;
namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            AutoResetEvent d = new AutoResetEvent(false);
            Console.WriteLine("d的类名称为：{0}", d.ToString());
            Console.WriteLine("获取控制此实例d的生存期策略的生存期服务对象\n{0}", d.InitializeLifetimeService());
            Console.WriteLine("将指定事件的状态设置为终止执行成功？：{0}\n将指定事件的状态设置为非终止执行成功？：{1}\n", d.Set(), d.Reset());
        }
    }
}
