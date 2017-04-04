using System;
using System.IO;
using System.Net;

namespace TestingAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://atom.io/");
            
            Console.WriteLine(reply);
            File.WriteAllText(@"D:\examples\WriteText.txt", reply);
            Console.ReadLine();
        }
    }
}
