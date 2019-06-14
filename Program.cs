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
        public class TextToFile
        {
            //定义一个字符串常量
            private const string FILE_NAME = "MyFile.txt";
            public static void Main(string[] args)
            {
                //如果文件存在就输出文件内容
                if(File.Exists(FILE_NAME))
                {
                    Console.WriteLine("这个文件已经存在，他的内容为：");
                    StreamReader rd = File.OpenText(FILE_NAME);
                    String input;
                    while((input=rd.ReadLine())!=null)
                    {
                        Console.WriteLine(input);
                    }
                    Console.WriteLine("文件流末尾到达，程序结束！！！。");
                    rd.Close();
                    return;
                }
                //如果这个文件不存在就创建文件
                StreamWriter sr = File.CreateText(FILE_NAME);
                sr.WriteLine("这个文件已经被创建成功！");
                sr.WriteLine("I can write ints {0} or floats {1}, and so on.", 1, 4.2);
                Console.WriteLine("我们创建了一个文本文件！!");
                sr.Close();
            }
        }
    }
}
