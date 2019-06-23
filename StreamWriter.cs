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
            public static void WriteLineTypes(Stream sink)
            {
                //创建一个输出流
                StreamWriter sw = new StreamWriter(sink);
                sw.WriteLine(true);
                sw.WriteLine(false);
                sw.WriteLine((byte)7);
                sw.WriteLine('z');
                sw.WriteLine(new char[] { 'A', 'B', 'C', 'D' });
                sw.WriteLine(new Decimal(123.45));
                sw.WriteLine((short)212);
                sw.WriteLine((long)212);
                sw.WriteLine("{0} : {1}", "string formatting supported", "true");
                sw.Close();
            }
        public static void Main(string[] args)
        {
            //以创建文件模式打开文件流
            Stream fStream = new FileStream("E:\\1\\实验\\实验\\textio.dat", FileMode.Create);
            WriteLineTypes(fStream);
            fStream.Close();
         }
    }
}
