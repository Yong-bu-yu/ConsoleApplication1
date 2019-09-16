using System;
using System.Text;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder d;
            //定义一个StringBuilder 实例，长度为32
            d = new StringBuilder("This is a test! ", 32);
            //输出这个d的值和长度值
            Console.WriteLine("First,StringBuilder's length is {0};\n他的字符串为{1}", d.Length, d.ToString());
            //向这个d中增加一个字符串
            d.Append("That is an examinatin");
            Console.WriteLine("Second,StringBuilder's length is {0};\n他的字符串为{1}", d.Length, d.ToString());
            //向这个d中增加几个不同类型的常量
            d.Insert(5, true);
            d.Insert(5, "\"");
            d.Insert(10,"\" ");
            Console.WriteLine("Third,StringBuilder's length is {0};\n他的字符串为{1}", d.Length, d.ToString());
        }
    }
}
