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
        public static void PrintIndexAndValues(IEnumerable myList)
        {
            int i = 0;
            IEnumerator myEnumerator = myList.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.WriteLine("\t{0}:\t{1}\n", i++, myEnumerator.Current);
        }
        public static void PrintValues(IEnumerable myList,int myWidth)
        {
            IEnumerator myEnumerator = myList.GetEnumerator();
            int i = myWidth;
            while(myEnumerator.MoveNext())
            {
                if(i<=0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.Write("\t{0}", myEnumerator.Current);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            BitArray myBA1 = new BitArray(4);
            BitArray myBA2 = new BitArray(4);
            myBA1[0] = myBA2[1] = false;
            myBA1[2] = myBA2[3] = true;
            myBA1[0] = myBA2[2] = false;
            myBA1[1] = myBA2[3] = true;
            Console.WriteLine("初始值为：");
            Console.Write("myBA1:");
            PrintValues(myBA1, 8);
            Console.Write("myBA2:");
            PrintValues(myBA2, 8);
            //And
            Console.WriteLine("And的结果为：");
            PrintValues(myBA1.And(myBA2), 8);
            Console.WriteLine("And操作之后：");
            Console.Write("myBA1:");
            PrintValues(myBA1, 8);
            Console.Write("myBA2:");
            PrintValues(myBA2, 8);
            //Xor
            Console.WriteLine("Xor的结果为：");
            PrintValues(myBA1.Xor(myBA2), 8);
            Console.WriteLine("Xor操作之后：");
            Console.Write("myBA1:");
            PrintValues(myBA1, 8);
            Console.Write("myBA2:");
            PrintValues(myBA2, 8);
            Console.WriteLine();
            try
            {
                BitArray myBA3 = new BitArray(8);
                myBA3[0] = myBA3[1] = myBA3[2] = myBA3[3] = false;
                myBA3[4] = myBA3[5] = myBA3[6] = myBA3[7] = true;
                myBA1.Xor(myBA3);
            }
            catch(Exception myException)
            {
                Console.WriteLine("异常：" + myException.ToString());
            }
            myBA1.SetAll(true);
            Console.WriteLine("所有元素的值为true,");
            PrintIndexAndValues(myBA1);
            myBA1.Set(myBA1.Count - 1, false);
            Console.WriteLine("最后一个元素为false,");
            PrintIndexAndValues(myBA1);
        }
    }
}
