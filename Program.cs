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
        public static void PrintKeysAndValues(Hashtable myList)
        {
            IDictionaryEnumerator myEnumerator = myList.GetEnumerator();
            Console.WriteLine("\t-KEY-\t-VALUE-");
            while (myEnumerator.MoveNext())
                Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
            Console.WriteLine();
            
        }
        //调用方法GetEnumerator()输出Hashtable的值
            static void Main(string[] args)
            {
                //创建并利用方法Add初始化一个Hashtable.
                Hashtable myHT = new Hashtable();
                myHT.Add("1a", "The");
                myHT.Add("1b", "quick");
                myHT.Add("1c", "fox"); 
                //显示这个Hashtable.
                Console.WriteLine("这个Hashtable包含下列的值：");
                PrintKeysAndValues(myHT);
                //删除关键字为"1b"的元素.
                myHT.Remove("1b");
                //显示当前的Hashtable.
                Console.WriteLine("删除\"quick\"之后：");
                //创建一个同步化的Hashtable.
                Hashtable mySyncdHT = Hashtable.Synchronized(myHT);
                //显示两个Hashtables的同步状态
                Console.WriteLine("myHT is {0}.", myHT.IsSynchronized ? "synchronized" : "not synchronized");
                Console.WriteLine("mySyncdHT is {0}.", myHT.IsSynchronized ? "synchronized" : "not synchronized");
            }
    }
}
