using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //创建一个WebClient对象
                WebClient client = new WebClient();
                Byte[] pageData = client.DownloadData("file:///E:/Projects/ConsoleApplication1/ConsoleApplication1/bin/Debug/one.htm");
                string pageHtml = Encoding.UTF7.GetString(pageData);
                Console.WriteLine(pageHtml);
                client.DownloadFile("file:///E:/Projects/ConsoleApplication1/ConsoleApplication1/bin", "tow.htm");
                Console.WriteLine("page.htm has been downloaded!");
            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx.ToString());
                //测试客户端和服务器端是否连接
                if (webEx.Status == WebExceptionStatus.ConnectFailure)
                    Console.WriteLine("Are you behind a firewall? If so, go through the proxy server.");
            }
        }
    }
}
