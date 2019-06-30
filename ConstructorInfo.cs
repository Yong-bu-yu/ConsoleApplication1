using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            ParameterInfo[] pi; Pointer k;
            //获取Queue类的类型
            Type type = Type.GetType("System.Collections.Queue");
            Console.WriteLine("Constructors forType{0}\n", type.ToString());
            //获取Queue类型的构造信息
            ConstructorInfo[] consts = type.GetConstructors();
            Console.WriteLine("\nNumber of constructor={0}", consts.GetLength(0));
            //在for循环中输出所有的Queue类型的构造信息
            for(int i=0;i<consts.GetLength(0);++i)
            {
                pi = consts[i].GetParameters();
                Console.WriteLine("\nconstructor {0} takes {1} input parameters", i, pi.GetLength(0));
                for(int j=0;j<pi.GetLength(0);++j)
                {
                    Console.WriteLine("\tparameters{0}:name={1} type={2}", pi[j].Position, pi[j].Name, pi[j].ParameterType);
                }
            }
        }
    }
}
