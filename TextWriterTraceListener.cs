using System;
using System.Diagnostics;
using System.IO;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            //打开一个文本文件流
            Stream myFile = File.Create("TestFile.txt");
            //根据myFile生成一个TextWriterTraceListener对象
            TextWriterTraceListener myTeextListener = new TextWriterTraceListener(myFile);
            //把myTextListener对象添加到Listeners
            Trace.Listeners.Add(myTeextListener);
            //根据控制台标准输出生成一个TextWriteTraceListener对象
            TextWriterTraceListener myWriter = new TextWriterTraceListener(Console.Out);
            Trace.Listeners.Add(myWriter);
            Trace.Write("Test output ");
            myWriter.WriteLine("Write only to the console screen.");
            Trace.Flush();
            myWriter.Close();
        }
    }
}
