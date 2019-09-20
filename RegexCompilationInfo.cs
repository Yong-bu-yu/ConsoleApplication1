using System;
using System.Reflection;
using System.Text.RegularExpressions;
namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //定义模式匹配字符串
            string pat = @"(\w+)\s+(car)";
            //建立正则式编译类实例
            RegexCompilationInfo rci = new RegexCompilationInfo(pat, RegexOptions.IgnoreCase, "CarRegex", "MyApp", true);
            //建立程序集合实例
            AssemblyName an = new AssemblyName();
            an.Name = "CarRegex_Cs";
            RegexCompilationInfo[] rcilist = { rci };
            //编译模式匹配字符串
            Regex.CompileToAssembly(rcilist, an);
            Console.WriteLine("RegexCompilationInfo's Namespace is {0}, Pattern is {1}", rci.Namespace, rci.Pattern);
        }
    }
}
