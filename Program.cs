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
        //定义按照字节方式读文件的函数
        static void ByteDump(Stream src)
        {
            int i = 0;
            while((i=src.ReadByte())!=-1)
                Console.Write("{0} = {1}", (char)i, i);
            Console.WriteLine();
        }

        //定义按照不同数据类型读取数据的函数
        static void ReadTypes(Stream src)
        {
            BinaryReader br = new BinaryReader(src);
            //从文件中读出一个布尔型数据
            bool b = br.ReadBoolean();
            Console.WriteLine(b);
            b = br.ReadBoolean();
            Console.WriteLine(b);
            //从文件读出一个字节的数据
            byte bt = br.ReadByte();
            Console.WriteLine(bt);
            byte[] byteArray = br.ReadBytes(bt);
            Console.WriteLine(byteArray);
            char c = br.ReadChar();
            Console.WriteLine(c);
            char[] charArray = br.ReadChars(4);
            Console.WriteLine(charArray);
            Decimal d = br.ReadDecimal();
            Console.WriteLine(d);
            Double db = br.ReadDouble();
            Console.WriteLine(db);
            short s = br.ReadInt16();
            Console.WriteLine(s);
            long l = br.ReadInt64();
            Console.WriteLine(l);
            string tag = br.ReadString();
            Console.WriteLine(tag);
        }
        public static void Main(string[] args)
        {
            //根据命令行参数，创建文件输出流
            Stream fStream = new BufferedStream(new FileStream(args[0], FileMode.Open));
            //按照字节方式读出文件内容，并显示字节码和相应的字符
            ByteDump(fStream);
            fStream.Close();
            //按照文件内容，读出相应的数据类型
            fStream = new BufferedStream(new FileStream(args[0], FileMode.Open));
            ReadTypes(fStream);
            fStream.Close();
         }
    }
}
