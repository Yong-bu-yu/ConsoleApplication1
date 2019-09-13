using System;
using System.IO;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //定义一个输出流
            StreamReader sr = new StreamReader(new BufferedStream(/*利用第一个命令行参数，打开一个文件流*/new FileStream(args[0], FileMode.Open)));
            StreamWriter sw = new StreamWriter(new BufferedStream(/*创建一个名称为redirect.dat*/new FileStream("redirect.dat", FileMode.Create)));
            Console.SetIn(sr);
            Console.SetOut(sw);
            Console.SetError(sw);
            string s;
            //在while结构中输出文件的内容
            while ((s = Console.In.ReadLine()) != null)
                Console.Out.WriteLine(s);
            Console.Out.Close();//Remember this!            
        }
    }
}
