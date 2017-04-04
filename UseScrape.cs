using ScrapeLibrary;
using System;

namespace ScrapeClassTesting
{
    class UseScrape
    {
        static void Main(string[] args)
        {
            Scrape myScrape = new Scrape();
            string outputString = myScrape.ScrapeWebPage("https://www.atom.io");
            Console.WriteLine(outputString);
            Console.ReadLine();
        }
    }
}
