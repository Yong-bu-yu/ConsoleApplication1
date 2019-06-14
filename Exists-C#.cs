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
        class MySteam
        {
            //定义一个字符串常量，声明文件名称
            private const string FILE_NAME = "Test.data";
            public static void Main(string[] args)
            {
                //判断文件是否存在
                if(File.Exists(FILE_NAME))
                {
                    Console.WriteLine("文件{0}已经存在！它的内容如下：", FILE_NAME);
                }
                else
                {
                    //如果文件不存在，就创建一个新的，空的文件流
                    Console.WriteLine("文件{0}不存在！我们将创建，并写入如下内容：", FILE_NAME);
                    FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew);
                    //创建一个二进制写入流
                    BinaryWriter w = new BinaryWriter(fs);
                    //向文件Test.data中写入整数
                    for(int i=0;i<11;i++)
                    {
                        w.Write(i);
                    }
                    w.Close();
                    fs.Close();
                }
                //创建一个二进制输出流
                FileStream rdfs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(rdfs);
                //从文件Test.data读出数据
                for(int i =0;i<11;i++)
                {
                    Console.WriteLine(r.ReadInt32());
                }
                r.Close();
            }
        }
    }
}
