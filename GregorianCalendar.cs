using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("Current Time is : {0:f}", dateTime);
            GregorianCalendar infol = new GregorianCalendar(GregorianCalendarTypes.TransliteratedEnglish);
            Console.WriteLine("Adjust the time : {0:F} ", infol.AddDays(dateTime, 4));
        }
    }
}
