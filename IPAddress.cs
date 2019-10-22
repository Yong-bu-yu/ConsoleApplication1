using System;
using System.Net;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPAddress hostIP = IPAddress.Parse(args[0]);
                IPHostEntry hostEntry = Dns.GetHostEntry(hostIP);
                string HostName = hostEntry.HostName;
                Console.WriteLine("IP :" + args[0] + " is : " + HostName);
            }
            catch (Exception)
            {
                Console.WriteLine("The IP you entered " + args[0] + " is invalid!!");
                throw;
            }
        }
    }
}
