using System;
using System.Collections;
using System.Collections.Specialized;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDictionary myCol = new StringDictionary();
            myCol.Add("red", "rojo");
            myCol.Add("green", "varde");
            myCol.Add("blue", "azul");
            Console.WriteLine("Initial contens of the StringDictionary.");
            PrintKeysAndValues(myCol);
            myCol.Remove("green");
            Console.WriteLine("The collection contains the following elements after removing \"green\":");
            PrintKeysAndValues(myCol);
            myCol.Clear();
            Console.WriteLine("The collection contains the following elements after it is cleared:");
            PrintKeysAndValues(myCol);
        }
        static void PrintKeysAndValues(StringDictionary myCol)
        {
            IEnumerator myEnumerator = myCol.GetEnumerator();
            Console.WriteLine("\tKEY\t\tVALUE");
            foreach (DictionaryEntry de in myCol)
                Console.WriteLine("\t{0,-10}\t{1}", de.Key, de.Value);
            Console.WriteLine();
        }
    }
}
