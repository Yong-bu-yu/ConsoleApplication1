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
            Console.WriteLine(myRequest.Headers);
            Console.WriteLine(myRequest.RequestUri);
            //WebResponse myResponse = myRequest.GetResponse();本人添加，不明下面代码有什么用
            myResponse.Close();
        }
    }
}
