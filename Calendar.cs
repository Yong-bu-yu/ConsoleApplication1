using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendar my = new GregorianCalendar();
            DateTime myTime = new DateTime(2003, 11, 3, 8, 42, 40, 100, my);
            Console.WriteLine("Current Time: {0}", myTime.ToUniversalTime());
            myTime = my.AddWeeks(myTime, 12);
            Console.WriteLine("After add 12 weeks, the timer is:{0}", myTime.ToLocalTime());
            Console.WriteLine("This yeaar is Leap Year?" + my.IsLeapYear(2003, 0));
        }
    }
}
