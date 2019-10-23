using System;
using System.Net;
using System.Net.Sockets;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            String hostName=args[0];
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
                IPAddress[] addrList = hostEntry.AddressList;
                Console.WriteLine(hostName + " has the following IP addresses : ");
                for (int i = 0; i < addrList.Length; i++)
                    Console.WriteLine(addrList[i]);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not retrieve information!");
            }
        }
    }
}
