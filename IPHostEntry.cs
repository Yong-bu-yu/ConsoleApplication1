using System;
using System.Net;
namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IPHostEntry myIP = Dns.GetHostEntry(args[0]);//Dns.Resolve(args[0]) 方法Resolve是否决的，应用GetHostEntry
                IPAddress[] addrList = myIP.AddressList;
                for (int i = 0; i < addrList.Length; i++)
                {
                    Console.WriteLine(addrList[i]);
                }
            }
            catch
            {
                Console.WriteLine("Could not find host name:"+args[0]);
            }
        }
    }
}
