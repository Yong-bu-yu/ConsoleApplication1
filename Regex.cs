using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            String input = "ted wanted the other ted to do it";
            Console.WriteLine("The source string is : " + input);
            //定义模式匹配的字符串
            String pattern = @"\b(ted)\b";
            //把ted替换成Ted
            String replace = "Ted";
            //利用正则式进行替换
            Regex regex = new Regex(pattern);
            String newString = regex.Replace(input, replace);
            Console.WriteLine("The target string is : " + newString);
        }
    }
}
