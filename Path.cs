using System;
using System.IO;
using System.Security;
using System.Text;

namespace 实验
{
    class Program
    {    
        //定义组合路径的方法
        private static void CombinePaths(string p1,string p2)
        {
            try
            {
                //调用Path类定义的组合方法来组合路径
                string combination = Path.Combine(p1, p2);
                Console.WriteLine("When you combine'{0}' and '{1}', the result is: {2}'{3}'", p1, p2, Environment.NewLine, combination);
            }
            catch(Exception e)
            {
                Console.WriteLine("You cannot combine '{0}' and '{1}' because: {2}{3}", p1, p2, Environment.NewLine, e.Message);
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            //定义六个路径字符串
            string path1 = "c:\\temp";
            string path2 = "subdir\\file.txt";
            string path3 = "c:\\temp.txt";
            string path4 = "c:^*&)(_=@#'\\^&#2.*(.txt";
            string path5 = "";
            string path6 = null;
            //把定义的路径字符串进行在组合
            CombinePaths(path1, path2);
            CombinePaths(path1, path3);
            CombinePaths(path3, path2);
            CombinePaths(path4, path2);
            CombinePaths(path5, path2);
            CombinePaths(path6, path2);
        }
    }
}
