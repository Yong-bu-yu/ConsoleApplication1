using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            //定义一个字符串含有两个HTTP地址
            String str = "This is " + "http://www.microsoft.com" + "That is http://www.sohu.com";
            String pattern = @"\b(\S+)://(\S+)?\b";
            //对字符串str进行正则式匹配，匹配结果集合存入MacthCollection集合
            MatchCollection matches = Regex.Matches(str, pattern);
            Console.WriteLine("number of matches is {0}", matches.Count);
            //获取匹配集合的枚举型结果
            IEnumerator matchEnum = matches.GetEnumerator();
            //输出枚举型数据
            while (matchEnum.MoveNext())
            {
                Console.WriteLine(matchEnum.Current);
            }
            //在for循环中输出所有匹配的结果
            for (int i = 0; i < matches.Count; i++)
            {
                GroupCollection groups = matches[i].Groups;
                Console.WriteLine("In match {0}," + "ther are {1}", i, groups.Count);
                //把匹配的每个Group结果送入枚举型集合
                IEnumerator groupEnum = groups.GetEnumerator();
                for (int j = 0; j < groups.Count; j++)
                {
                    CaptureCollection captures = groups[j].Captures;
                    Console.WriteLine("Group {0}," + "has {1} capture", j, captures.Count);
                    for (int k = 0; k < captures.Count; k++)
                    {
                        Console.WriteLine(captures[k].Value);
                    }
                }
            }
        }
    }
}
