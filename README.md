### C# Basics
[MVA C# Fundamentals for Absolute Beginners](https://mva.microsoft.com/en-us/training-courses/c-fundamentals-for-absolute-beginners-16169?l=Lvld4EQIC_2706218949)

## 017 Using .NET Assemplies
* The *.NET Class Library* is a collection of classes. The code is split into multiple files, the *.NET assemblies*. In order to make use of them we add the appropriate *using* statements.
* In this example we use the *System.IO* and the *System.Net* assemblies.
* In order to use the *File.WriteAllText* method so that we can write a string to a file, we must first add the `using System.Net` statement in our code.
* In order to use the *WebClient* *DownloadString* method so that we can grab the data from a url to a string, we must first add the `using System.IO` statement in our code.
```
    WebClient client = new WebClient();
    string reply = client.DownloadString("https://atom.io/");

    Console.WriteLine(reply);
    File.WriteAllText(@"D:\examples\WriteText.txt", reply);
    Console.ReadLine();
```

## 018.1 Create a Class Library
* In this example we will create the *ScrapeLibrary* project, which will contain a public class that we will call *Scrape*.
* It will contain an overloaded method called *ScrapeWebpage*. Its first version will be receiving only a *url* parameter, while the second version  will be receiving a *url* as well as a *filepath* parameter.
* The first version downloads as a string and returns the data from the url we provide, while the second version saves the string to the filepath we provide.
* The private helper method *GetWebpage* encapsulates the functionality of downloading as a string and returning the data from the url we provide. It is called in both versions of *ScrapeWebpage*.
```
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
```
