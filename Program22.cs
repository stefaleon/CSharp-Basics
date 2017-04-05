using System;
using System.IO;

namespace ReadAFile
{
    class Program
    {
        static void Main(string[] args)
        {
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
            finally
            {
                Console.WriteLine("This is from code in 'finally', which runs no matter what.");
                Console.WriteLine("Press 'Enter' to exit.");
            }
            Console.ReadLine();
        }
    }
}
