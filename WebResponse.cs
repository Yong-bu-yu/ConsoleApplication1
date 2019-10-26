using System;
using System.Collections;
using System.Net;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest myRequest = WebRequest.Create("http://www.baidu.com");
            WebResponse myResponse = myRequest.GetResponse();
            Console.WriteLine(myResponse.ResponseUri);
            Console.WriteLine(myResponse.Headers);
            myResponse.Close();
        }
    }
}
