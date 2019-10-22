using System;
using System.Net;
using System.Net.Sockets;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry hostEntry = Dns.GetHostEntry("www.baidu.com");
            IPEndPoint host = new IPEndPoint(hostEntry.AddressList[0], 80);
            try
            {
                s.Connect(host);
                Console.WriteLine("This Connection has been established!");
            }
            catch (Exception ane)
            {
                Console.WriteLine(ane.Message);
            }
        }
    }
}
