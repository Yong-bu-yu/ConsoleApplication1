using System;
using System.Globalization;
using System.Text;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo myInv = new NumberFormatInfo();
            UnicodeEncoding myUE = new UnicodeEncoding(true, false);
            byte[] myCodes;
            Console.WriteLine("NumberFormatInfo:\nNote: Symbols may not display correctly on the console,\ntherefore, Unicode values are included.");
            Console.WriteLine("\tCurrencyDecimalDigits\t\t{0}", myInv.CurrencyDecimalDigits);
            Console.WriteLine("\tCurrencyDecimalSeparator\t{0}", myInv.CurrencyDecimalSeparator);
            Console.WriteLine("\tCurrencyGroupSeparator\t\t{0}", myInv.CurrencyGroupSeparator);
            Console.WriteLine("\tCurrencyGroupSizes\t\t{0}", myInv.CurrencyGroupSizes[0]);
            myCodes = myUE.GetBytes(myInv.CurrencySymbol);
            Console.WriteLine("\tCurrencySymbol\t\t\t{0}\t(U+1:x2}{2:x2})", myInv.CurrencySymbol, myCodes[0], myCodes[1]);
            //利用控制台输出更多的NumberFormatInfo对象的属性
        }
    }
}
