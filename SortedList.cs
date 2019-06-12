using Microsoft.Win32;
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
        public static void PrintIndexAndKeysAndValues(SortedList myList)
        {
            Console.WriteLine("\t-INDEX-\t-VALUE-");
            for (int i = 0; i < myList.Count; i++)
                Console.WriteLine("\t[{0}]:\t{1}\t{2}", i, myList.GetKey(i), myList.GetByIndex(i));
            Console.WriteLine();
        }
            static void Main(string[] args)
            {
                SortedList mySL = new SortedList();
                mySL.Add(0, "zero");
                mySL.Add(1, "one");
                mySL.Add(2, "two");
                mySL.Add(3, "three");
                mySL.Add(4, "four");
                //加入更多的元素
                Console.WriteLine("SortedList包含的所有值为：");
                PrintIndexAndKeysAndValues(mySL);
                int myKey = 2;
                Console.WriteLine("Key为\"{0}\"其索引为index{1},对应的值为{2}.", myKey, mySL.IndexOfKey(myKey), mySL.GetByIndex(myKey));
                String myValue = "three";
                Console.WriteLine("查询的值为\"{0}\"其索引为index{1}", myValue, mySL.IndexOfValue(myValue));
                myKey = 2;
                Console.WriteLine("查询的Key值为\"{0}\"{1}.", myKey, mySL.ContainsKey(myKey) ? "在这个SortedList中" : "不在这个SortedList中");
                myKey = 6;
                Console.WriteLine("查询的Key值为\"{0}\"{1}.", myKey, mySL.ContainsKey(myKey) ? "在这个SortedList中" : "不在这个SortedList中");
                myValue = "three";
                Console.WriteLine("查询的value值为\"{0}\"{1}", myValue, mySL.ContainsValue(myValue) ? "在这个SortedList中" : "不在这个SortedList中");
                myValue = "nine";
                Console.WriteLine("查询的value值为\"{0}\"{1}", myValue, mySL.ContainsValue(myValue) ? "在这个SortedList中" : "不在这个SortedList中");
                //利用方法SetByIndex替换索引为3和4.
                mySL.SetByIndex(3, "III");
                mySL.SetByIndex(4, "IV");
                //显示更新后排SortedList
                Console.WriteLine("替换索引为3和4后，");
                PrintIndexAndKeysAndValues(mySL);
                //调用方法Remove删除key为3的元素
                mySL.Remove(3);
                //显示当前的SortedList
                Console.WriteLine("删除key为3的元素之后：");
                PrintIndexAndKeysAndValues(mySL);
            }
    }
}
