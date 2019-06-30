using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //获取System.Object的类型
            Type myTpye = typeof(Object);
            //获取System.dll的路径
            string system = Regex.Replace(myTpye.Assembly.CodeBase, "mscorlib.dll", "System.dll");
            system = Regex.Replace(system, "file:///","");
            //获取程序集的信息并显示
            AssemblyName myAssemblyName = AssemblyName.GetAssemblyName(system);
            Console.WriteLine("\nDisplaying the assembly information of 'System.dll'\n");
            Console.WriteLine(myAssemblyName.ToString());
        }
    }
}
