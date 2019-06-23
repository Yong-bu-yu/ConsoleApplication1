using Microsoft.Win32;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stream s = new MemoryStream();//创建内存流s,然后以字节方式写入0-99
            for (int i = 0; i < 100; i++)
                s.WriteByte((byte)i);
            s.Position = 0;//现在把内存流s中的内容读入到字节缓冲区buffer
            byte[] bytes = new byte[1000];
            int numBytesToread = (int)s.Length;
            int numBytesRead = 0;
            while(numBytesToread>0)//在while循环结构读出文件的内容
            {
                int n = s.Read(bytes, numBytesRead, numBytesToread);
                if (n == 0)//读到流末尾处停止
                    break;
                numBytesRead += n;
                numBytesToread -= n;
            }
            s.Close();
            int nn = 0;
            while(nn<numBytesRead)
            {
                Console.Write("{0,3}\t", bytes[nn++]);
                if (nn % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("Number of bytes read: " + numBytesRead);
         }
    }
}
