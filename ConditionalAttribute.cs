using System;
using System.Diagnostics;

namespace 实验
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            TextWriterTraceListener myWriter = new TextWriterTraceListener(Console.Out);
            Debug.Listeners.Add(myWriter);
            Console.WriteLine("Console.WriteLine is always displayed");
            Method1();
            Method2();
        }
        [Conditional("CONDITION1")]
        public static void Method1()
        {
            Debug.Write("Method1 - DEBUG and CONDITION1 are specified\n");
            Trace.Write("Method1 - DEBUG and TRACE are specified\n");
        }
        [Conditional("CONDITION2")]
        public static void Method2()
        {
            Debug.Write("Method2 - DEBUG, CONDITION1 or CONDITION2 are specified\n");
        }
    }
}
//右击 项目->属性->生成->条件编译符号 CONDITION1或CONDITION2
