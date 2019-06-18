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
        //建立文件输出流
        static void LinePrint(Stream src)
        {
            StreamReader r = new StreamReader(src);
            int line = 0;
            string aLine = "";//循环以行为单位输出文件内容，并输出相应行号
            while((aLine=r.ReadLine())!=null)
            {
                Console.WriteLine("{0}:{1}", line++, aLine);
            }
        }
        public static void Main(string[] args)//利用foreach循环接受命令行参数中的文本文件名
        {
            foreach(string fName in args)//根据输入的文件名建立文件流
            {
                Stream src = new BufferedStream(new FileStream(fName, FileMode.Open));
                //调用函数LinePrint逐行输出文件内容
                LinePrint(src);
                src.Close();
            }
         }
    }
}
