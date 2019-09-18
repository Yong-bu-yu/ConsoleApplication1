using System;
using System.Text.RegularExpressions;

namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            string text = "One car red blue car";
            //定义一个正则式匹配模式
            string pat = @"(\w+)\s+(car)";
            //根据pat定义一个Regex实例
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            int matchCount = 0;
            //输出捕获的集合内容
            while (m.Success)
            {
                Console.WriteLine("Match" + (++matchCount));
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    Console.WriteLine("Group" + i + "='" + g + "'");
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        Console.WriteLine("Capture" + j + "='" + c + "',Position=" + c.Index);
                    }
                }
                m.NextMatch();
            }
        }
    }
}
