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
        public static void PrintValues(IEnumerable myCollection)
        {
            IEnumerator myEnumerator = myCollection.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.Write("\t{0}", myEnumerator.Current);
            Console.WriteLine();
        }
        public static void PrintValues(Array myArr,char mySeparator)
        {
            IEnumerator myEnumerator = myArr.GetEnumerator();
            int i = 0;
            int cols = myArr.GetLength(myArr.Rank - 1);
            while(myEnumerator.MoveNext())
            {
                if (i < cols)
                    i++;
                else
                {
                    Console.WriteLine();
                    i = 1;
                }
                Console.Write("{0}{1}",mySeparator, myEnumerator.Current);
            }
            Console.WriteLine();
        }
        public static void PrintValues(Object[] myArr,char mySeparator)
        {
            foreach(Object myObj in myArr)
                Console.Write("{0}{1}", mySeparator, myObj);
            Console.WriteLine();
        }
            static void Main(string[] args)
            {
                //创建并调用方法Enqueue初始化一个Queue
                Queue mySourceQ = new Queue();
                mySourceQ.Enqueue("three");
                mySourceQ.Enqueue("napping");
                mySourceQ.Enqueue("cats");
                mySourceQ.Enqueue("in");
                mySourceQ.Enqueue("the");
                mySourceQ.Enqueue("barn");
                Console.WriteLine("初始的Queue为：");
                PrintValues(mySourceQ);
                //创建并初始化一个一维数组.
                Array myTaragetArray = Array.CreateInstance(typeof(String), 15);
                myTaragetArray.SetValue("The", 0);
                myTaragetArray.SetValue("quick", 1);
                myTaragetArray.SetValue("brown", 2);
                myTaragetArray.SetValue("fox", 3);
                myTaragetArray.SetValue("jumped", 4);
                myTaragetArray.SetValue("over", 5);
                myTaragetArray.SetValue("the", 6);
                myTaragetArray.SetValue("lazy", 7);
                myTaragetArray.SetValue("dog", 8);
                //加入更多元素
                Console.WriteLine("这个目标数组包含下列的内容（执行方法CopyTo之前和之后）：");
                PrintValues(myTaragetArray, ' ');
                //把整个队列都复制到目标数组中去，从第6个位置开始
                mySourceQ.CopyTo(myTaragetArray, 6);
                //显示目标数组
                PrintValues(myTaragetArray, ' ');
                //把这个队列复制到一个标准的数组中去
                Object[] myStandardArray = mySourceQ.ToArray();
                //显示这个新数组.
                Console.WriteLine("这个新的标准数组含有以下内容：");
                PrintValues(myStandardArray, ' ');
                Console.WriteLine("调用方法Dequeue()删除“{0}”之后，队列的内容为：",mySourceQ.Dequeue());
                PrintValues(mySourceQ);
                Console.WriteLine("调用方法Peek()获得“{0}”之后，队列的内容为：",mySourceQ.Peek());
                PrintValues(mySourceQ);
                //调用方法Clear清除这个队列
                mySourceQ.Clear();
                //显示队列的计算器count
                Console.WriteLine("执行Clear方法之后，");
                Console.WriteLine("  Count  :{0}", mySourceQ.Count);
                Console.Write("  Values:");
                PrintValues(mySourceQ);
            }
    }
}
