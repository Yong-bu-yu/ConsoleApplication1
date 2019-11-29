using System;
using System.Diagnostics;

namespace 实验//SFCS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            实验1.Class1 myClass = new 实验1.Class1();
            try
            {
                myClass.MyMethod();
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                Console.WriteLine(" StackTrace: " + st.ToString());
                Console.WriteLine(" Line Number: " + st.GetFrame(0).GetFileLineNumber().ToString());
                Console.WriteLine("--------------------------------------------------------------");
            }
        }
    }
}
namespace 实验1//SFCS1
{
    public class Class1
    {
        public void MyMethod()
        {
            try
            {
                实验2.Class1 myClass = new 实验2.Class1();
                myClass.MyMethod();
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace(new StackFrame(1));
                Console.WriteLine(" StackTrace: " + st.ToString());
                Console.WriteLine(" StackFrame: " + st.GetFrame(0).ToString());
                Console.WriteLine(" Line Number: " + st.GetFrame(0).GetFileLineNumber().ToString());
                Console.WriteLine("------------------------------------------------------------\n");
                throw e;
            }
        }
    }
}
namespace 实验2//SFCS2
{
    public class Class1
    {
        public void MyMethod()
        {
            throw new Exception("StackFrame Example");
        }
    }
}
