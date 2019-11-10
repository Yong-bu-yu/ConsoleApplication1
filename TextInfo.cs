using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            string mystr = "This is a test!";
            CultureInfo cultureinfo = new CultureInfo(4, true);
            TextInfo myTextinfo = cultureinfo.TextInfo;
            Console.WriteLine("ANSICodePage : " + myTextinfo.ANSICodePage);
            Console.WriteLine("ListSeparator : " + myTextinfo.ListSeparator);
            Console.WriteLine("ToLower : " + myTextinfo.ToLower(mystr));
            Console.WriteLine("ToUpper : " + myTextinfo.ToUpper(mystr));
            Console.WriteLine("ToTitleCase : " + myTextinfo.ToTitleCase(mystr));
        }
    }
}
