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
