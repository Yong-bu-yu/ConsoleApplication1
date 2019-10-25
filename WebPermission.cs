using System;
using System.Collections;
using System.Net;
namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个WebPermission实例，连接到本地
            WebPermission myWebPermissionnl = new WebPermission(NetworkAccess.Connect, "https://brushes8.com");
            myWebPermissionnl.Demand();
            //增加两个访问网络连接
            myWebPermissionnl.AddPermission(NetworkAccess.Connect, "http://www.baidu.com");
            myWebPermissionnl.AddPermission(NetworkAccess.Connect, "http://www.12315.cn");
            myWebPermissionnl.Demand();
            IEnumerator myEnum1 = myWebPermissionnl.ConnectList;
            Console.WriteLine("\n\nThe URIs with Accept permission are :\n");
            while (myEnum1.MoveNext())
                Console.WriteLine("\tThe URI is : " + myEnum1.Current);
        }
    }
}
