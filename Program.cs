using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 实验
{
    class Program
    {
        public static void PrintValues(IEnumerable myList)
        {
            IEnumerator myEnumerator = myList.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.Write("\t{0}", myEnumerator.Current);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            ArrayList arraylist = new ArrayList();
            Console.WriteLine("输入十个数，可排序，可插入一个数，使顺序不变。");
            for(int i=0;i<10;i++)
            {
                arraylist.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("排序之后的数：");
            arraylist.Sort();
            PrintValues(arraylist);
            Console.WriteLine("插入一个数之后：");
            arraylist.Insert(0, Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("排序之后的数：");
            arraylist.Sort();
            PrintValues(arraylist);
        }
    }
}

