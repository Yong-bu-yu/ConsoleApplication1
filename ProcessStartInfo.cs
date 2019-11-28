using System;
using System.Diagnostics;

namespace 实验
{
    class Program
    {
        public static void OpenApplication(string myFavoritesPath)
        {
            Process.Start("IExplore.exe");
            Process.Start(myFavoritesPath);
        }
        public static void OpenWithArguments()
        {
            //by passing them as arguments.
            Process.Start("IExplore.exe", "www.northwindtraders.com");
            //Start a Web page using a browser associated with .html and .asp files.
            Process.Start("IExplore.exe", "C:\\myPath\\myFile.htm");
            Process.Start("IExplore.exe", "C:\\myPath\\myFile.asp");
        }
        public static void OpenWithStartInfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(startInfo);
            startInfo.Arguments = "www.northwindtraders.com";
            Process.Start(startInfo);
        }
        static void Main(string[] args)
        {
            //Get the path that stores favorite links
            string myFavoritesPath = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            OpenApplication(myFavoritesPath);
            OpenWithArguments();
            OpenWithStartInfo();
        }        
    }
}
