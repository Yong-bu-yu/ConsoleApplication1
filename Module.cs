using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义一个程序集，并加载程序集SomeSports
            Assembly assembly = Assembly.Load("SomeSports");
            //定义一个模块，并获取程序集assembly的SomeSports.dll模块
            Module module = assembly.GetModule("SomeSports.dll");
            //获取模块module的Football的类型
            Type[] types = module.FindTypes(Module.FilterTypeName, "Football");
            //输出Football类型的名称
            if (types.Length != 0)
            {
                ConstructorInfo ci = types[0].GetConstructor(new Type[0]);
                Sports program = (Sports)ci.Invoke(new Object[0]);
                Console.WriteLine("Sport's name is :" + program.ToString());
            }
            else
                Console.WriteLine("Type not found");
            //获取相关的程序集的属性值
            Module mod = Assembly.GetEntryAssembly().GetModules()[0];
            Console.WriteLine("Module Name is " + mod.Name);
            Console.WriteLine("Module FullyQualifiedName is " + mod.FullyQualifiedName);
            Console.WriteLine("Module ScopeName is " + mod.ScopeName);
        }
    }
}
