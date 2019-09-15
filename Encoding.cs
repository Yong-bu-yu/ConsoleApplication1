using System;
using System.IO;
using System.Text;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //定义一个StreamReder实例，并以ASSCII方式读出文本文件的内容
            StreamReader srRead = new StreamReader((Stream)File.OpenRead("text.txt"), Encoding.ASCII);
            //把文件指针定位在文件开始处
            srRead.BaseStream.Seek(0, SeekOrigin.Begin);
            srRead.BaseStream.Position = 0;
            char[] buffer = new char[1];
            int a = 0;
            Console.WriteLine("不支持中文情况下的Test.txt的内容如下：");
            //以ASSCII码方式输出流的内容
            while (a<srRead.BaseStream.Length)
            {
                srRead.Read(buffer, 0, 1);
                a++;
                Console.Write("{0}", buffer[0].ToString());
            }
            Console.WriteLine("\n文件已经读取完毕！");
            //释放缓冲区的内容
            srRead.DiscardBufferedData();
            srRead.Close();
            //以中文的方式读出文本文件的内容到流中
            srRead = new StreamReader((Stream)File.OpenRead("text.txt"), Encoding.GetEncoding("gb2312"));
            //把文件指针定位在文件开始处
            srRead.BaseStream.Seek(0, SeekOrigin.Begin);
            srRead.BaseStream.Position = 0;
            buffer = new char[1];
            a = 0;
            Console.WriteLine("支持中文情况下的Text.txt的内容如下：");
            //以中文方式输出流的内容
            while (a < srRead.BaseStream.Length) 
            {
                srRead.Read(buffer, 0, 1);
                a++;
                Console.Write("{0}", buffer[0].ToString());
            }
        }
    }
}
