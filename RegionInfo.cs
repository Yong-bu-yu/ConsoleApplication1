using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            RegionInfo myRIl = new RegionInfo("US");
            //输出区域myRIl的属性值
            Console.WriteLine("Name: {0}", myRIl.Name);
            Console.WriteLine("DisplayName: {0}", myRIl.DisplayName);
            Console.WriteLine("EnglishName: {0}", myRIl.EnglishName);
            Console.WriteLine("ThreeLetterISORegionName:{0}", myRIl.ThreeLetterISORegionName);
            Console.WriteLine("ThreeLetterWindowsRegionName: {0}", myRIl.ThreeLetterWindowsRegionName);
            Console.WriteLine("TwoLetterISORegionName: {0}", myRIl.TwoLetterISORegionName);
            Console.WriteLine("CurrencySymbol: {0}", myRIl.CurrencySymbol);
            Console.WriteLine("ISOCurrencySymbol: {0}", myRIl.ISOCurrencySymbol);
            Console.WriteLine();
            RegionInfo myRI2 = new RegionInfo(new CultureInfo("en-US", false).LCID);
            //对两个区域信息对象进行比较
            if (myRIl.Equals(myRI2))
                Console.WriteLine("The two RegionInfo instances are equal.");
            else
                Console.WriteLine("The two RegionInfo instances are NOT equal.");
        }
    }
}
