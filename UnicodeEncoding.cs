using System;
using System.Text;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            UnicodeEncoding d;
            byte[] my = new byte[30];
            char[] your = new char[15];
            d = new UnicodeEncoding();
            //把字符串"this is a test!"转变成UTF-16形式
            d.GetBytes("This is a test!", 0, 15, my, 0);
            //调用GetChars方法转换成字符串形式
            d.GetChars(my, 0, 30, your, 0);
            //输出转换后的your字符串
            Console.WriteLine(your);
            //输出UTF-16的my的内容
            Console.WriteLine("{0},{1}", d.GetEncoder(), d.GetString(my, 0, 30));
            Console.WriteLine("{0},{1},{2}", d.BodyName, d.EncodingName, d.CodePage);
        }
    }
}
