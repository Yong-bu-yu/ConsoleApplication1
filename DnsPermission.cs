using System;
using System.Collections;
using System.Net;
using System.Security;
namespace 实验
{
    class Program
    {
        public static void Main(string[] args)
        {
            DnsPermission permission = new DnsPermission(System.Security.Permissions.PermissionState.Unrestricted);
            permission.Demand();
            //创建一个SecurityElement对象来控制DnsPermission实例
            SecurityElement securityElementObj = permission.ToXml();
            Console.WriteLine("Tag,Attributes and Values of 'DnsPermission' instance :");
            //输出属性名称和值
            PrintKeysAndValues(securityElementObj.Attributes);
        }
        static void PrintKeysAndValues(Hashtable myList)
        {
            //通过hash表获得枚举每个值
            IDictionaryEnumerator myEnumertor = myList.GetEnumerator();
            Console.WriteLine("\t-KEY-\tVALUE-");
            while (myEnumertor.MoveNext())
                Console.WriteLine("\t{0}:\t{1}", myEnumertor.Key, myEnumertor.Value);
            Console.WriteLine();
        }
    }
}
