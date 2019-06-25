using System;
using System.IO;

namespace 实验
{
    public class Program
    {
        //由命令输入文件名或目录名，由方法File.Exists()和方法Directory.Exists()决定调用相应的处理程序
        public static void Main(string[] args)
        {
            foreach(string path in args)
            {
                if (File.Exists(path))
                    //输入的是存在的文件名
                    ProcessFile(path);
                else if (Directory.Exists(path))
                    //输入的是存在的目录名
                    ProcessDirectory(path);
                else Console.WriteLine("{0} is not a valid file or dirctory.", path);
            }
         }
        //定义方法列出目录下的文件名和子目录名
        public static void ProcessDirectory(string targetDirectory)
        {
            //输出目录下的文件列表
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);
            //递归定义输出子目录的列表
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        //输出文件列表
        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }
    }
}
