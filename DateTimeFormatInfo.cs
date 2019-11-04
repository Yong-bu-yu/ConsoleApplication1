using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeFormatInfo my = new DateTimeFormatInfo();
            Calendar myCalendar = new GregorianCalendar();
            DateTime myData = new DateTime(2003, 11, 7, 21, 3, 40, 100, myCalendar);
            myCalendar = my.Calendar;
            Console.WriteLine("Currenet time is : " + myData.ToLocalTime() + my.AMDesignator);
            Console.WriteLine(my.CalendarWeekRule+ "\t" + my.FullDateTimePattern);
            Console.WriteLine(my.UniversalSortableDateTimePattern);
            Console.WriteLine(my.SortableDateTimePattern);
            Console.WriteLine(my.RFC1123Pattern);
        }
    }
}
