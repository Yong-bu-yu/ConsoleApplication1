using System;
using System.Text;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //以UTF8编码定义一个Decoder实例
            Decoder decoder = Encoding.UTF8.GetDecoder();
            //定义两个字节型数组
            byte[] buf1 = { 0x0061, 0x002b, 0x0064, 0x003d, 0x00c6 };
            byte[] buf2 = { 0x00a9, 0x0028, 0x0062, 0x002b, 0x0063, 0x0029 };
            char[] charArray = new char[10];
            //把第一个字节型数组的内容解码到字符型数组中
            int i = decoder.GetChars(buf1, 0, buf1.Length, charArray, 0);
            //把第二个字节型数组的内容解码到字符型数组中
            decoder.GetChars(buf2, 0, buf2.Length, charArray, i);
            Console.WriteLine(charArray);
        }
    }
}
