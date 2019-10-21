using System;
using System.Collections;
using System.Net;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri HttpSite = new Uri("http://www.baidu.com");
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(HttpSite);
            Console.WriteLine(myRequest.RequestUri);
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //输出myResponse对象的各种属性值
            Console.WriteLine("ContentLength : " + myResponse.ContentLength);
            Console.WriteLine("ContentType : " + myResponse.ContentType);
            Console.WriteLine("LastModified : " + myResponse.LastModified);
            Console.WriteLine("Method : " + myResponse.Method);
            Console.WriteLine("ProtocolVersion : " + myResponse.ProtocolVersion);
            Console.WriteLine("Server : " + myResponse.Server);
            Console.WriteLine("StatusCode : " + myResponse.StatusCode);
            Console.WriteLine("StatusDescription : " + myResponse.StatusDescription);
        }
    }
}
