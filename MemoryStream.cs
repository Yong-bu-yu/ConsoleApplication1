using System;
using System.IO;
using System.Text;

namespace 实验
{
    class Program
    {
        //定义源流类SourceStream
        class SourceStream
        {
            Stream src;
            public SourceStream(Stream src)
            {
                this.src = src;
            }
            public void ReadAll()
            {
                //定义读取流中所有数据的方法
                Console.WriteLine("Reading stream ofTypeis: " + src.GetType());
                int nextByte;
                //在while循环中以字节方式读出所有数据
                while ((nextByte = src.ReadByte()) != -1) 
                {
                    Console.Write((char)nextByte);
                }
            }
        }
        //定义一个内存流，并初始化内容
        static SourceStream ForMemoryStream()
        {
            string aString = "I am a good student,you are not a good student!";
            UTF8Encoding ue = new UTF8Encoding();
            byte[] bytes = ue.GetBytes(aString);
            //创建内存流MemoryStream存储数据
            MemoryStream memStream = new MemoryStream(bytes);
            SourceStream srcStream = new SourceStream(memStream);
            return srcStream;
        }
        static SourceStream ForFileStream()
        {
            //定义一个文件流，并将文件内容写入该流
            string fName = "text.txt";
            //创建文件流，准备输入数据
            FileStream fStream = new FileStream(fName, FileMode.Open);
            SourceStream srcStream = new SourceStream(fStream);
            return srcStream;
        }
        public static void Main(string[] args)
        {
            //定义一个内存缓冲区流
            SourceStream srcStr = ForMemoryStream();
            //以字节方式读出所有内存内容
            srcStr.ReadAll();
            Console.WriteLine();
            //打开一个文件流
            srcStr = ForFileStream();
            //以字节方式读出文件所有内容
            srcStr.ReadAll(); 
            Console.WriteLine();
        }
    }
}
