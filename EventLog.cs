using System;
using System.Diagnostics;
using System.IO;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            string myRemoteMechine;
            string myLogName = "MyLog";
            Console.WriteLine("Enter computer on which to create log : ");
            myRemoteMechine = Console.ReadLine();
            if (!EventLog.SourceExists("MyTestSource"))
            {
                EventSourceCreationData data = new EventSourceCreationData(myLogName, myRemoteMechine);
                EventLog.CreateEventSource(data);
                Console.WriteLine("Creating EventSource");
            }
            else
                //Get the EventLog associated if the source exists.
                myLogName = EventLog.LogNameFromSourceName("MyTestSource", myRemoteMechine);
            EventLog myEventLog = new EventLog(myLogName, myRemoteMechine);
            myEventLog.Source = "MyTestSource";
            myEventLog.WriteEntry("This is for your information", EventLogEntryType.SuccessAudit, 100);
            Console.WriteLine("An EventLog created on computer " + myEventLog.MachineName);
            EventLog[] remoteEventLogs = EventLog.GetEventLogs("127.0.0.1");
            Console.WriteLine("Nuber of logs on computer: " + remoteEventLogs.Length);
            foreach (EventLog log in remoteEventLogs)
                Console.WriteLine("Log: " + log.Log);
        }
    }
}
