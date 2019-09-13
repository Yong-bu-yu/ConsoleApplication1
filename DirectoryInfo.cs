using System;
using System.IO;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //创建一个指向目录的引用
            DirectoryInfo di = new DirectoryInfo("TempDir");
            //利用公共属性Exists判断，如果这个目录不存在，就创建一个新的
            if (di.Exists == false)
                di.Create();
            //在目录TempDir下利用方法创建CreateSubdirectory("SubDir")一个子目录
            DirectoryInfo dis = di.CreateSubdirectory("SubDir");
            DirectoryInfo[] diArr = di.GetDirectories();
            //输出这个目录TempDir下的子目录名字
            foreach (DirectoryInfo dri in diArr)
                Console.WriteLine(dri.Name);
                //把目录TempDir连同他的内容移到目标位置上
            if (Directory.Exists("NewTempDir")==false)
            {
                di.MoveTo("NewTempDir");
                try
                {
                    //试图删除子目录，但是他已经被移到了新位置，所以会出现异常
                    dis.Delete(true); 
                }
                catch (Exception)
                {
                    //处理这个异常
                    Console.WriteLine("这个目录不存在！");
                }
                try
                {
                    //确定子目录的新位置，然后输出它
                    di = new DirectoryInfo("NewTempDir");
                    di.Delete(true);
                    Console.WriteLine("删除成功");
                }
                catch (Exception)
                {
                    Console.WriteLine("删除失败" );
                }
            }
        }
    }
}
