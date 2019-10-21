using System;
using System.Collections;
using System.Net;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri HttpSite = new Uri("http://127.0.0.1");
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(HttpSite);
            Console.WriteLine("Address: " + myRequest.Address);
            Console.WriteLine("AllowAutoRedirect: " + myRequest.AllowAutoRedirect);
            //利用方法Console.WriteLine输出HttpWebRequest各种属性
            Console.WriteLine("AllowWriteStreamBuffering: " + myRequest.AllowWriteStreamBuffering);
            Console.WriteLine("HaveResponse: " + myRequest.HaveResponse);
            Console.WriteLine("KeepAlive: " + myRequest.KeepAlive);
            Console.WriteLine("MaximumAutomaticRedirections: " + myRequest.MaximumAutomaticRedirections);
            Console.WriteLine("Method: " + myRequest.Method);
            Console.WriteLine("RequstUri: " + myRequest.RequestUri);
        }
    }
}
