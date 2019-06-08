using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 实验
{
    class Program
    {
        static void PrintKeys(RegistryKey rkey)
        {
            //调用RegistryKey类的方法GetSubKeyNames获取注册表中各项的名称
            String[] names = rkey.GetSubKeyNames();
            int icount = 0;
            Console.WriteLine("Subkeys of " + rkey.Name);
            Console.WriteLine("-------------------------------------------------------");
            foreach(String s in names)
            {
                Console.WriteLine(s);
                icount++;
                if (icount >= 9)
                    break;
            }
        }
        static void Main(string[] args)
        {
            RegistryKey rk = Registry.ClassesRoot;
            PrintKeys(rk);
        }
    }
}
