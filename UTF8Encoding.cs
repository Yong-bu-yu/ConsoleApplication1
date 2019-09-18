using System;
using System.Text;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //定义一个UTF8Encoding类型的解码实例
            UTF8Encoding encoder = new UTF8Encoding(true);
            //定义一个字符串含有一个UTF8字符
            String str = "I like " + '\u03a0';
            //把字符串str解码到字节型数组中
            byte[] buf = new byte[encoder.GetByteCount(str)];
            int j = encoder.GetBytes(str, 0, str.Length, buf, 0);
            for(int i=0;i<buf.Length;i++)
            {
                //在for循环中输出解码后的内容
                Console.WriteLine("byte {0} is {1,2:X}", i, buf[i]);
            }
            Console.WriteLine();
            Console.WriteLine(encoder.GetString(buf));
        }
    }
}
