using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            string mystr = "This is a text!";
            Console.WriteLine("\n利用方法GetNextTextElement输出字符串：");
            for (int i = 0; i < mystr.Length; i++)
            {
                Console.Write("{0}", StringInfo.GetNextTextElement(mystr, i));
            }
            Console.WriteLine("\n利用TextElementEnumerator输出字符串：");
            TextElementEnumerator textEnumerator = StringInfo.GetTextElementEnumerator(mystr, 0);
            while (textEnumerator.MoveNext())
                Console.Write(textEnumerator.Current);
            Console.WriteLine();
        }
    }
}
