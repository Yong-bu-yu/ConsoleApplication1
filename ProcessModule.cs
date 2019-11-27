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
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("notepad.exe");
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.Start();
                Thread.Sleep(1000);
                ProcessModule myProcessModule;
                ProcessModuleCollection myProcessModuleCollection = myProcess.Modules;
                Console.WriteLine("Properties of the modules associated with 'notepad' are:");
                for (int i = 0; i < myProcessModuleCollection.Count; i++)
                {
                    myProcessModule = myProcessModuleCollection[i];
                    Console.WriteLine("The moduleName is " + myProcessModule.ModuleName);
                    Console.WriteLine("The " + myProcessModule.ModuleName + "'s base address is: " + myProcessModule.EntryPointAddress);
                    Console.WriteLine("The " + myProcessModule.ModuleName + "'s File name is: " + myProcessModule.FileName);
                }
                myProcessModule = myProcess.MainModule;
                Console.WriteLine("process's main module's base address is: " + myProcessModule.BaseAddress);
                Console.WriteLine("The process's main module's base address is: " + myProcessModule.EntryPointAddress);
                Console.WriteLine("The process's main module's File name is: " + myProcessModule.FileName);
                myProcess.CloseMainWindow();
            }
            catch (Exception e)
            {
                Console.WriteLine("The following exception was raised " + e.Message);
            }
        }        
    }
}
