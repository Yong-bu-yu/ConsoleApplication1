using System;
using System.Net;
using System.Net.Sockets;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 11000);
            SocketAddress socketAddress = ipLocalEndPoint.Serialize();
            Console.WriteLine("Contents of the socketAddress are: " + socketAddress.ToString());
            Console.WriteLine("The address family of the socketAddress is: " + socketAddress.Family.ToString());
            Console.WriteLine("The size of the underlying buffer is: " + socketAddress.Size.ToString());
        }
    }
}
