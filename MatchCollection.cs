using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //定义了一个字符串，并且包含两个HTTP地址信息
            String str = "This is " + "http://www.microsoft.com" + "That is http://www.sohu.com";
            String pattern = @"\b(\S+)://(\S+)?\b";
            //对字符串str进行正则式匹配
            MatchCollection matches = Regex.Matches(str, pattern);
            Console.WriteLine("number of matches is {0}", matches.Count);
            IEnumerator matchEnum = matches.GetEnumerator();
            //输出匹配的结果
            while (matchEnum.MoveNext())
            {
                Console.WriteLine(matchEnum.Current);
            }
        }
    }
}
