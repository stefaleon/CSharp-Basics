### C# Basics
[MVA C# Fundamentals for Absolute Beginners](https://mva.microsoft.com/en-us/training-courses/c-fundamentals-for-absolute-beginners-16169?l=Lvld4EQIC_2706218949)


&nbsp;
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
&nbsp;
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
&nbsp;
## 018.2 Create and use *ScrapeLibrary.dll*
* In order to create *ScrapeLibrary.dll*, we can select *Release* in Visual Studio and build the solution.
* We can create a testing project, where we will add *ScrapeLibrary.dll* as a reference.
* In order to use the *Scrape* class, we will be `using ScrapeLibrary;`.
* We can create an instance of *Scrape*, call *ScrapeWebpage* for an existing url and output the url's data as a string in the console.
```
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
```
&nbsp;
## 018.3 Include the *Scrape* library and the *UseScrape* testing program in *ScrapeSolution*
* In Visual Studio we can select to create a new project of *Visual Studio Solution* type. We can call it *ScrapeSolution*.
* We can add the two projects containing the *Scrape* library and the *UseScrape* testing program.
* Now we can have all related code in a single Visual Studio solution and run the testing code after we make sure we have it set *as a StartUp project*.
* Use a debug build configuration or disable the debug option *Enable Just My Code* in order to stop warning messages.


&nbsp;
## 022 Exceptions Handling
* Consider the following piece of code, where with the help of the *System.IO.File.ReadAllText* method we read the content of a text file. Then we write it to the console.
```
using System;
using System.IO;

namespace ReadAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = File.ReadAllText(@"D:\some.txt");
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
}
```
* Various errors may occur due to many possible scenarios, such as file missing, misspelling of the filename, wrong path etc. In order to protect the user from cryptic system messages and provide a better experience, we can wrap the code in a *try* block and use a *catch* block for the error case. If everything is fine, the *try* block will be executed. If an exception occurs, the catch block can provide the user with helpful messages, including the specific exception message given by *ex.Message*.
```
            try
            {
                string content = File.ReadAllText(@"D:\asdf\some.txt");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine(ex.Message);
            }
```
* A *finally* block can be added, where cleaning up for our application can be implemented, since this block will be executed in all cases.
```
            finally
            {
                Console.WriteLine("This is from code in 'finally', which runs no matter what.");
                Console.WriteLine("Press 'Enter' to exit.");
            }
            Console.ReadLine();
        }
```
&nbsp;
## 023.1 Handling Events, Timer example
* In order to demonstrate a simple event handling example, we will use the *Timer* object. To do that, we start with `using System.Timers;`.
* We create the *myTimer* instance of the *Timer* class by calling the constructor and assigning a value of 2000 to the *interval* parameter.
```
Timer myTimer = new Timer(2000);
```
* The *Elapsed* event will be getting raised every 2 seconds (2000 msec) and our handler code will be getting called every time this happens. We assign the *MyTimer_Elapsed* handler to the event and set it to call the *SignalTime* event argument, which displays the time when the event was raised.
```
    myTimer.Elapsed += MyTimer_Elapsed;

private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Elapsed: {0:hh:mm:ss:fff}", e.SignalTime);
    }
```
* Get the timer ticking by calling the *Start()* method.
```
myTimer.Start();
```
* We can add more event handlers, such as *MyTimer_Elapsed1*, *MyTimer_Elapsed2*, etc. They also will be getting called and execute the including code when the event is fired.
