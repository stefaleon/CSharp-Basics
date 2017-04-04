using System.IO;
using System.Net;

namespace ScrapeLibrary
{
    public class Scrape
    {
        public string ScrapeWebPage(string url)
        {
            string reply = GetWebpage(url);
            return reply;
        }

        public string ScrapeWebPage(string url, string filepath)
        {            
            string reply = GetWebpage(url);
            File.WriteAllText(filepath, reply);
            return reply;
        }

        private string GetWebpage(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
    }
}
