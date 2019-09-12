using System;
using System.IO;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //创建内存流s，然后以字节方式写入0-99
            Stream s = new MemoryStream();
            for (int i = 0; i < 100; i++)
                s.WriteByte((byte)i);
            s.Position = 0;//现在把内存流s中的内容读入到字节缓冲区buffer
            byte[] bytes = new byte[1000];
            int numBytesToRead = (int)s.Length;
            int numBytesRead = 0;
            //在while循环结构读出文件的内容
            while (numBytesToRead > 0)
            {
                int n = s.Read(bytes, numBytesRead, numBytesToRead);
                if (n == 0)//读到流末尾处停止
                    break;
                numBytesRead += n;
                numBytesToRead -= n;
            }
            s.Close();
            int nn = 0;
            //将缓冲区的内容读出来显示到屏幕上
            while (nn < numBytesRead)
            {
                Console.Write("{0} ", bytes[nn++]);
                if (nn % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("number of bytes read: " + numBytesRead);
        }
    }
}
