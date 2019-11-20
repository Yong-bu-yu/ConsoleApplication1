using System;
using System.Collections;
using System.Collections.Specialized;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates and initializes a new HybridDictionary.
            HybridDictionary myCol = new HybridDictionary();
            myCol.Add("Breaburn Apples", "1.49");
            myCol.Add("Fuji Apples", "1.29");
            myCol.Add("Marshal Apples", "1.31");
            myCol.Add("Plums", "0.9");
            myCol.Add("JonaGold Apples", "2.32");
            myCol.Add("MalusDomestica Apples", "1.5");
            myCol.Add("GoldenDelicious Apples", "0.5");
            //增加更多的项目
            //Displays the values in the HybridDictionary in three differnt ways.
            Console.WriteLine("Initial contents of the HybridDictionary:");
            PrintKeysAndValues(myCol);
            //Deletes a key.
            myCol.Remove("Plums");
            Console.WriteLine("The collection contains the following elements after removing \"Plums\":");
            PrintKeysAndValues(myCol);
            //Clears the entire collection.
            myCol.Clear();
            Console.WriteLine("The collection contains the following elements after after it is cleared:");
            PrintKeysAndValues(myCol);
        }
        public static void PrintKeysAndValues(IEnumerable myCol)
        {
            IEnumerator myEnumerator = myCol.GetEnumerator();
            Console.WriteLine("  KEY                       VALUE");
            foreach (DictionaryEntry de in myCol)
                Console.WriteLine("  {0,-25} {1}", de.Key, de.Value);
            Console.WriteLine();
        }
    }
}
