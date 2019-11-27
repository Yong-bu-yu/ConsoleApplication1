using System;
using System.Diagnostics;
using System.Threading;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            Process myProcess = Process.Start("NotePad.exe");
            Thread.Sleep(1000);
            foreach (ProcessThread my in myProcess.Threads)
            {
                Console.WriteLine("Base priority of the associated process: ", my.BasePriority);
                //Get user processor time for this process.
                Console.WriteLine("User Processor Time: " + my.UserProcessorTime);
                //Get privileged processor time for this process.
                Console.WriteLine("Privileged ProcessorTime: " + my.PrivilegedProcessorTime);
                //Get total processor time for this process.
                Console.WriteLine("Total Processor Time: " + my.TotalProcessorTime);
                //Invoke overloaded ToString function.
                Console.WriteLine("Process's Name: " + my.ToString());
                Console.WriteLine("----------------------------------------------------------");
            }
        }        
    }
}
