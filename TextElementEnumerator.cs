using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "\uD800\uDC00\u0061\u0300\u00C6";
            TextElementEnumerator myTEE = StringInfo.GetTextElementEnumerator(myString);
            Console.WriteLine("Index\tCurrent\tGetTexElement");
            myTEE.Reset();
            while (myTEE.MoveNext())
                Console.WriteLine("[{0}]:\t{1}\t{2}", myTEE.ElementIndex, myTEE.Current, myTEE.GetTextElement());
        }
    }
}
