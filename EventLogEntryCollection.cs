using System;
using System.Collections;
using System.Diagnostics;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string myLogName = "MyNewLog";
                if (!EventLog.SourceExists("MySource"))
                {
                    EventLog.CreateEventSource("MySource", myLogName);
                    Console.WriteLine("Creating EventSource");
                }
                else
                    myLogName = EventLog.LogNameFromSourceName("MySource", ".");
                EventLog myEventLog2 = new EventLog();
                myEventLog2.Source = "MySource";
                myEventLog2.WriteEntry("Successfully created a new Entry in the Log");
                myEventLog2.Close();
                EventLog myEventLog1 = new EventLog();
                myEventLog1.Log = myLogName;
                //Obtain the Log Entries of "MyNewLog"
                EventLogEntryCollection myEventLogEntryCollection = myEventLog1.Entries;
                myEventLog1.Close();
                Console.WriteLine("The number of entries in 'MyNewLog' = " + myEventLogEntryCollection.Count);
                //Display the 'Message' property of EventLogEntry.
                for (int i = 0; i < myEventLogEntryCollection.Count; i++)
                {
                    Console.WriteLine("The Message of the EventLog is :" + myEventLogEntryCollection[i].Message);
                }
                //Copy the EventLog entries to Array of type EventLogEntry.
                EventLogEntry[] myEventLogEntryArray = new EventLogEntry[myEventLogEntryCollection.Count];
                myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0);
                IEnumerator myEnumerator = myEventLogEntryArray.GetEnumerator();
                while (myEnumerator.MoveNext())
                {
                    EventLogEntry myEventLogEntry = (EventLogEntry)myEnumerator.Current;
                    Console.WriteLine("The LocalTime the Event is generated is " + myEventLogEntry.TimeGenerated);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }
        }
    }
}
