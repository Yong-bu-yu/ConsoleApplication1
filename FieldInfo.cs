using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public int myField1 = 0;
        protected string myField2 = null;
        public static void Main(string[] args)
        {
            FieldInfo[] myFieldInfo;
            //获取本类定义的信息
            Type myType = typeof(Program);
            //获取本类所定义的属性信息
            myFieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            Console.Write("\nThe fields related to 'FieldInfoClass' class are \n");
            for(int i=0;i<myFieldInfo.Length;i++)
            {
                Console.WriteLine("\nName:\t{0}", myFieldInfo[i].Name);
                Console.WriteLine("DeclaringType:\t{0}", myFieldInfo[i].DeclaringType);
                Console.WriteLine("IsPublic:\t{0}", myFieldInfo[i].IsPublic);
                Console.WriteLine("MemberType:\t{0}", myFieldInfo[i].MemberType);
                Console.WriteLine("FieldType:\t{0}", myFieldInfo[i].FieldType);
                Console.WriteLine("IsFamily:\t{0}", myFieldInfo[i].IsFamily);
            }
        }
    }
}
