using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Array array = Array.CreateInstance(typeof(int), 10, 10);
            array.Initialize();
            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for (int j = array.GetLowerBound(0); j <= array.GetUpperBound(0); j++)
                {
                    if (i == j || j == 0)  
                    array.SetValue(1, i, j);
                    if (i != 0 && j != 0) 
                    array.SetValue(Convert.ToInt32(array.GetValue(i - 1, j - 1)) + Convert.ToInt32(array.GetValue(i - 1, j)), i, j);
                    if (j % 10 == 0)
                        Console.WriteLine();
                    if(Convert.ToInt32(array.GetValue(i,j))!=0)
                    Console.Write(array.GetValue(i, j)+"   ");
                }
            }
        }
    }
}
