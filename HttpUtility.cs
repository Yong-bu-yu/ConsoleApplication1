using System;
using System.IO;
using System.Web;


namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString;
            Console.WriteLine("Enter a string having '&' or '\"' in it:");
            //键盘上读入一个字符串
            myString = Console.ReadLine();
            string myEncodedString;
            //对字符串进行编码
            myEncodedString = HttpUtility.HtmlEncode(myString);
            StringWriter myWriter = new StringWriter();
            //对字符串进行解码
            HttpUtility.HtmlDecode(myEncodedString, myWriter);
            Console.WriteLine("Decode string of the above encoded string is " + myWriter.ToString());
        }
    }
}
