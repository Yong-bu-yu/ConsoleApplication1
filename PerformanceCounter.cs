using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace 实验
{
    class Program
    {
        private static PerformanceCounter PC;
        private static PerformanceCounter BPC;
        static void Main(string[] args)
        {
            ArrayList samplesList = new ArrayList();
            SetupCategory();
            CreateCounters();
            CollectSamples(samplesList);
        }
        private static bool SetupCategory()
        {
            if (!PerformanceCounterCategory.Exists("AverageCounter64SampleCategory"))
            {
                CounterCreationDataCollection CCDC = new CounterCreationDataCollection();
                CounterCreationData averageCount64 = new CounterCreationData();
                averageCount64.CounterType = PerformanceCounterType.AverageCount64;
                averageCount64.CounterName = "AverageCounter64Sample";
                CCDC.Add(averageCount64);
                CounterCreationData averageCount64Base = new CounterCreationData();
                averageCount64Base.CounterType = PerformanceCounterType.AverageBase;
                averageCount64Base.CounterName = "AverageCounter64Base";
                CCDC.Add(averageCount64Base);
                PerformanceCounterCategory.Create("AverageCounter64SampleCategory", "Demonstrates usage of the AverageCounter64 performance counter type.",PerformanceCounterCategoryType.MultiInstance, CCDC);
                return (true);
            }
            else
            {
                Console.WriteLine("Category exists - AverageCounter64SampleCategory");
                return (false);
            }
        }
        private static void CreateCounters()
        {
            PC = new PerformanceCounter("AverageCounter64SampleCategory", "AverageCounter64Sample", false);
            BPC = new PerformanceCounter("AverageCounter64SampleCategory", "AverageCounter64SampleBase", false);
            PC.RawValue = 0;
            BPC.RawValue = 0;
        }
        private static void CollectSamples(ArrayList samplesList)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int j = 0; j < 100; j++)
            {
                int value = r.Next(1, 10);
                Console.Write(j + "=" + value);
                PC.IncrementBy(value);
                BPC.Increment();
                if((j%10)==0)
                {
                    OutputSample(PC.NextSample());
                    samplesList.Add(PC.NextSample());
                }
                Thread.Sleep(50);
            }
        }
        private static void OutputSample(CounterSample s)
        {
            Console.WriteLine("\r\n+++++++++++++++++++++++");
            Console.WriteLine("Sample values - \r\n");
            Console.WriteLine(" BaseValue\t=", s.BaseValue);
            Console.WriteLine(" CounterFrequency =", s.CounterFrequency);
            Console.WriteLine(" CounterTimeStamp =", s.CounterTimeStamp);
            Console.WriteLine(" CounterType\t=", s.CounterType);
            Console.WriteLine(" RawValue\t=", s.RawValue);
            Console.WriteLine(" SystemFrequency =", s.SystemFrequency);
            Console.WriteLine(" TimeStamp\t=", s.TimeStamp);
            Console.WriteLine(" TimeStamp100nSec =", s.TimeStamp100nSec);
            Console.WriteLine("++++++++++++++++++++++++++++");
        }
    }
}
