using System;
using System.Diagnostics;
using System.Threading;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process myProcess;
                myProcess = Process.Start("NotePad.exe");
                while (true)
                {
                    Console.WriteLine("Process's physical memory usage:" + myProcess.WorkingSet64);
                    Console.WriteLine("Base priority of the associated process." + myProcess.BasePriority);
                    Console.WriteLine("User Processor Time:" + myProcess.UserProcessorTime);
                    Console.WriteLine("Privileged ProcessorTime:" + myProcess.PrivilegedProcessorTime);
                    Console.WriteLine("Process's Name:" + myProcess.ToString());
                    Console.WriteLine("---------------------------------------");
                    if(myProcess.HasExited)
                    {
                        Console.WriteLine("The process has exited");
                        break;
                    }
                    if (myProcess.Responding)
                    {
                        Console.WriteLine("Status:Responding to user interface");
                        myProcess.Refresh();
                    }
                    else
                        Console.WriteLine("Status:Not Responding");
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The following exception was raised " + e.Message);
            }
        }
    }
}
