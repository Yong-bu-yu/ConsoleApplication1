using System;
using System.IO;
using System.Security;

namespace 实验
{
    class Program
    {        
        public static void Main(string[] args)
        {
            Program snippets = new Program();
            
            //调用方法GetCurrentDirectory()获取当前目录
            string path = Directory.GetCurrentDirectory();
            string filter = "*.exe";
            //输出path目录中的文件名列表，子目录列表
            snippets.PrintFileSystemEntries(path);
            //输出满足检索条件（*.exe）的文件列表
            snippets.PrintFileSystemEntries(path, filter);
            //获取逻辑驱动器
            snippets.GetLogicalDrives();
            //获取父目录
            snippets.GetParent(path);
            //实现目录移动
            snippets.Move(args[0], args[1]);
        }
        void PrintFileSystemEntries(string path)
        {
            try
            {
                //获取目录path的文件系统入口参数
                string[] directoryEntries = Directory.GetFileSystemEntries(path);
                foreach (string str in directoryEntries)
                    Console.WriteLine(str);
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Path is a null reference.");
            }
            catch(SecurityException)
            {
                Console.WriteLine("The caller does not have the required permission.");
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Path is an empty string contains only white spaces or contains invalid characters.");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("The path encapsulated in the Directory object does not exits.");
            }
        }
            void PrintFileSystemEntries(string path,string pattern)
            {
                try
                {
                    //获取与检索模式匹配的文件系统入口参数.
                    string[] directoryEntries=Directory.GetFileSystemEntries(path,pattern);
                    Console.WriteLine();
                    foreach(string str in directoryEntries)
                        Console.WriteLine(str);
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("The caller does not havve the required permission.");
                }
                catch(SecurityException)
                {
                    Console.WriteLine("Path is an empty string contains only white spaces or contains invalid characters.");
                }
                catch(DirectoryNotFoundException)
                {
                    Console.WriteLine("The path encapsulated in the Directory object does not exist");
                }
            }
        //打印出所有的系统逻辑驱动器
        void GetLogicalDrives()
            {
                try
                {
                    string[] drives = Directory.GetLogicalDrives();
                    Console.WriteLine();
                    foreach (string str in drives)
                        Console.WriteLine(str);
                }
            catch(IOException)
                {
                    Console.WriteLine("An I/O error occurs.");
                }
            catch(SecurityException)
                {
                    Console.WriteLine("The caller does not have the required permission.");
                }
            }
        void GetParent(string path)
        {
            Console.WriteLine();
            try
            {
                DirectoryInfo directoryInfo = Directory.GetParent(path);
                Console.WriteLine(directoryInfo.FullName);
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Path is a null reference.");
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Path is an empty string contains only white spaces or contains invalid characters.");
            }
        }
        void Move(string sourcePath,string destinationPath)
        {
            Console.WriteLine();
            try
            {
                Directory.Move(sourcePath, destinationPath);
                Console.WriteLine("The directory move is complete.");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Path is a null reference.");
            }
            catch(SecurityException)
            {
                Console.WriteLine("The caller odes not have the required permission.");
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Path is an empty string contains only white spaces or contains invalid characters.");
            }
            catch(IOException)
            {
                Console.WriteLine("An attempt was made to move a directory to a different volume or destDirName already exists.");
            }
        }
    }
}
