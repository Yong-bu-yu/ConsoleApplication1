using System;
using System.IO;

namespace 实验
{
    class Program
    {
        //定义方法WriteTypes调用方法Write向文件写入各种类型的数据
        static void WriteTypes(Stream sink)
        {
            //基于文件流创建一个BinaryWriter对象
            BinaryWriter bw = new BinaryWriter(sink);
            bw.Write(true);
            bw.Write(false);
            bw.Write((byte)7);
            bw.Write(new byte[] { 1, 2, 3, 4 });
            bw.Write('z');
            bw.Write(new char[] { 'A', 'B', 'C', 'D' });
            bw.Write(new decimal(123.45));
            bw.Write(123.45);
            bw.Write((short)212);
            bw.Write((long)212);
            bw.Write("<boolean>treu</boolean>");
            bw.Write("你好，我的世界！");
        }
        
        public static void Main(string[] args)
        {
            //创建一个文件binaryio.dat,并向这个文件写入各种类型的数据
            //以创建的方式打开文件流
            Stream fStream = new FileStream("E:\\1\\实验\\实验\\bin\\Debug\\binaryio.dat", FileMode.Create);
            WriteTypes(fStream);
            fStream.Close();
            Console.WriteLine("文件binaryio.dat 写入成功! 程序结束。");
           
        }
    }
}
