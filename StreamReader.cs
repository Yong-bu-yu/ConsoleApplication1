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
            StreamReader srRead = new StreamReader((Stream)File.OpenRead("Text.txt"), Encoding.ASCII);//把文件指针定位在文件开始处
            srRead.BaseStream.Seek(0, SeekOrigin.Begin);
            srRead.BaseStream.Position = 0;
            char[] buffer = new char[1];
            int a = 0;
            Console.WriteLine("Text.txt的内容如下：");
            //在while结构输出文件内容
            while (a < srRead.BaseStream.Length)
            {
                srRead.Read(buffer, 0, 1);
                a++;
                Console.Write("{0}", buffer[0].ToString());
            }
            Console.WriteLine("\n文件已经读取完毕！");
            //清除文件缓冲区
            srRead.DiscardBufferedData();
            srRead.Close();
         }
    }
}
