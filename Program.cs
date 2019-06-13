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
        //利用枚举数来输出数组内容
        public static void PrintValues(IEnumerable myCollection,char mySeparator)
        {
            IEnumerator myEnumerator = myCollection.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.Write("{0}{1}", mySeparator, myEnumerator.Current);
            Console.WriteLine();
        }

        //利用foreach输出实例
        public static void PrintValues(Object [] myArr,char mySeparator)
        {
            foreach (Object myObj in myArr)
                Console.Write("{0}{1}", mySeparator, myObj);
            Console.WriteLine();
        }

        //利用枚举数到输出数组内容
        public static void PrintValues(Array myArr,char mySeparator)
        {
            IEnumerator myEnumerator = myArr.GetEnumerator();
            int i = 0;
            int cols = myArr.GetLength(myArr.Rank - 1);
            while(myEnumerator.MoveNext())
            {
                if(i<cols)
                    i++;
                else
                {
                    Console.WriteLine();
                    i = 1;
                }
                Console.Write("{0}{1}",mySeparator,myEnumerator.Current);
            }
            Console.WriteLine();
        }
            static void Main(string[] args)
            {
                //初始化并利用方法Push初始化一个堆栈
                Stack mySourceQ = new Stack();
                mySourceQ.Push("barn");
                mySourceQ.Push("the");
                mySourceQ.Push("in");
                mySourceQ.Push("cats");
                mySourceQ.Push("napping");
                mySourceQ.Push("three");
                Console.Write("最初Stack内容：");
                PrintValues(mySourceQ, '\t');
                //创建并利用方法SetValue初始化一个一维数组
                Array myTargetArray = Array.CreateInstance(typeof(String), 15);
                myTargetArray.SetValue("The", 0);
                myTargetArray.SetValue("quick", 1);
                myTargetArray.SetValue("brown", 2);
                myTargetArray.SetValue("fox", 3);
                myTargetArray.SetValue("jumped", 4);
                myTargetArray.SetValue("over", 5);
                myTargetArray.SetValue("the", 6);
                myTargetArray.SetValue("lazy", 7);
                myTargetArray.SetValue("dog", 8);
                //显示数组内容
                Console.WriteLine("目标数组含有下面内容：");
                PrintValues(myTargetArray, ' ');
                //利用CopyTo将整个堆栈赋值到从第6个位置开始的目标数组中
                mySourceQ.CopyTo(myTargetArray, 6);
                //显示当前目标数组的内容
                Console.WriteLine("调用CopyTo之后，目标数组含有下面内容：");
                PrintValues(myTargetArray, ' ');
                //调用方法ToArray把整个堆栈内容复制到一个新的标准数组中
                Object[] myStandardArray = mySourceQ.ToArray();
                //显示新数组的内容
                Console.WriteLine("调用ToArray方法得到的新数组的内容为：");
                PrintValues(myStandardArray, ' ');
                //调用方法Pop进行出栈操作
                Console.WriteLine("(Pop)\t\t{0}", mySourceQ.Pop());
                //显示堆栈内容
                Console.Write("Pop之后Stack内容：");
                PrintValues(mySourceQ, '\t');
            }
    }
}
