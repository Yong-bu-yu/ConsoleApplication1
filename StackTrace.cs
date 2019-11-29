using System;
using System.Diagnostics;

namespace 实验
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //调用方法MyPulbicMethod
                MyPublicMethod();
            }
            catch (Exception)
            {
                //设置跟踪堆栈
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    //在for循环中输出跟踪堆栈的内容
                    StackFrame sf = st.GetFrame(i);
                    Console.WriteLine("\nHigh Up the Call Stack, Method: {0}", sf.GetMethod());
                    Console.WriteLine("High Up the Call Stack, Line Number: {0}", sf.GetFileLineNumber());
                }
            }
        }
        public static void MyPublicMethod()
        { MyProtectedMethod(); }
        protected static void MyProtectedMethod()
        {
            MyInternalClass mic = new MyInternalClass();
            mic.ThrowsException();
        }
        class MyInternalClass
        {
            public void ThrowsException()
            {
                try
                {
                    throw new Exception("A problem was encountered.");
                }
                catch (Exception e)
                {
                    StackTrace st = new StackTrace(true);
                    string stackIndent = "";
                    for (int i = 0; i < st.FrameCount; i++)
                    {
                        StackFrame sf = st.GetFrame(i);
                        Console.WriteLine("\n" + stackIndent + " Method: {0}", sf.GetMethod());
                        Console.WriteLine(stackIndent + " File: {0}", sf.GetFileName());
                        Console.WriteLine(stackIndent + " Line Number: {0}", sf.GetFileLineNumber());
                        stackIndent += " ";
                    }
                    throw e;
                }
            }
        }
    }
}
