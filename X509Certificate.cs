using System;
using System.Security.Cryptography.X509Certificates;

namespace 实验
{
    class Program
    {
        static void Main(string[] args)
        {
            //The path to the certificate.
            string Certificate = "Certificate.cer";
            //Load the certificate into an X509Certificate object.
            X509Certificate cert = X509Certificate.CreateFromCertFile(Certificate);
            //Get the value.
            string resultsTrue = cert.ToString(true);
            //Display the value to the console.
            Console.WriteLine(resultsTrue);
            //Get the value.
            string resultsFalse = cert.ToString(false);
            //Display the value to the console.
            Console.WriteLine(resultsFalse);
        }
    }
}
