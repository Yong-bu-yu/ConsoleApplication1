using System;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            string text = "One car red blue car";
            //定义一个匹配模式字符串
            string pat = @"(?<1>\w+)\s+(?<2>car)\s*";
            //根据匹配模式字符串pat生成一个Regex实例
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            //对字符串text进行正则式匹配
            Match m = r.Match(text);
            while (m.Success)
            {
                //在while循环中输出匹配的结果
                Console.WriteLine("Match={" + m + "}");
                //捕获匹配的结果集合
                CaptureCollection cc = m.Captures;
                //输出集合的名称
                foreach (Capture c in cc)
                {
                    Console.WriteLine("Capture=[" + c + "]");
                }
                //获取集合中的第一组Group
                Group g1 = m.Groups[1];
                Console.WriteLine("Group1=[" + g1 + "]");
                //输出第一组Group的名称
                foreach (Capture c1 in g1.Captures)
                {
                    Console.WriteLine("Capturel=[" + c1 + "]");
                }
                //获取集合中的第二组Group
                Group g2 = m.Groups[2];
                Console.WriteLine("Group2=[" + g2 + "]");
                foreach (Capture c2 in g2.Captures)
                {
                    Console.WriteLine("Capture2=[" + c2 + "]");
                }
                //匹配指针指向下一组匹配集合
                m = m.NextMatch();
            }
        }
    }
}
