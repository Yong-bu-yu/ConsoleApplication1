using System;
using System.Globalization;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareInfo myComp_enUS = new CultureInfo("en-US", false).CompareInfo;
            SortKey mySKl = myComp_enUS.GetSortKey("llama");
            CompareInfo myComp_esEs = new CultureInfo("es-ES", false).CompareInfo;
            SortKey mySK2 = myComp_esEs.GetSortKey("llama");
            CompareInfo myComp_es = new CultureInfo(0x040A, false).CompareInfo;
            SortKey mySK3 = myComp_es.GetSortKey("llama");
            Console.WriteLine("Comparing \"llama\" in en-US and in es-ES with international sort : {0}", SortKey.Compare(mySKl, mySK2));
            Console.WriteLine("Comparing \"llama\" in en-US and in es-ES with traditional sort : {0}", SortKey.Compare(mySKl, mySK3));
        }
    }
}
