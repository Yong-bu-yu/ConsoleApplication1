using System;
using System.Collections;
using System.Collections.Specialized;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates and initializes a StringCollection.
            StringCollection myCol = new StringCollection();
            String[] myArr = new string[] { "red", "orange", "yellow", "green", "blue", "indigo", "violet" };
            myCol.AddRange(myArr);
            //Enumerates the elements in the StringCollection.
            StringEnumerator myEnumerator = myCol.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.WriteLine("{0}", myEnumerator.Current);
            Console.WriteLine();
            //Resets the enumerator and displays the first element again.
            myEnumerator.Reset();
            if (myEnumerator.MoveNext())
                Console.WriteLine("The first element is {0}.", myEnumerator.Current);
        }
    }
}
