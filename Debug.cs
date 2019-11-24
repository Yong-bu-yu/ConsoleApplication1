using System;
using System.Diagnostics;
using System.IO;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a file for output named TestFile.txt
            string myFileName = "TestFile.txt";
            if (!File.Exists(myFileName))
                File.Create(myFileName);
            //Assign output file to output stream.
            StreamWriter myOutputWiter = File.AppendText(myFileName);
            //Create a new text writer using the output stream, and add it to the trace listeners.
            TextWriterTraceListener myTextListener = new TextWriterTraceListener(myOutputWiter);
            Debug.Listeners.Add(myTextListener);
            Debug.WriteLine("Test output");
            Debug.Flush();
            Debug.Close();
        }
    }
}
