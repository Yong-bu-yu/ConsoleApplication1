using System;
using System.Diagnostics;
using System.Reflection;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //获取当前正在运行的进程
            Process p = Process.GetCurrentProcess();
            //获取正在运行的进程名称
            string assemblyName = p.ProcessName + ".exe";
            Console.WriteLine("Examining:{0}", assemblyName);
            //把正在运行的进程加入装配类中
            Assembly a = Assembly.LoadFrom(assemblyName);
            Type[] types = a.GetTypes();
            //输出所有的装配类中的类名称
            foreach (Type t in types)
            {
                Console.WriteLine("\nType:{0}", t.FullName);
                Console.WriteLine("\nBase class:{0}", t.BaseType.FullName);
            }
        }
    }
}
