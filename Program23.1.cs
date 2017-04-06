using System;
using System.Timers;

namespace TimerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer myTimer = new Timer(2000);

            myTimer.Elapsed += MyTimer_Elapsed;
            myTimer.Elapsed += MyTimer_Elapsed1;
            myTimer.Elapsed += MyTimer_Elapsed2;

            myTimer.Start();

            Console.WriteLine("Press 'Enter' to stop the green messages!");
            Console.ReadLine();
            myTimer.Elapsed -= MyTimer_Elapsed2;

            Console.WriteLine("Press 'Enter' again to stop the red messages!");
            Console.ReadLine();
            myTimer.Elapsed -= MyTimer_Elapsed1;

            Console.WriteLine("Press 'Enter' again to exit.");
            Console.ReadLine();

        }

        private static void MyTimer_Elapsed2(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This is from 'Elapsed2'!");
        }

        private static void MyTimer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Elapsed1: {0:hh:mm:ss:fff}", e.SignalTime);
        }

        private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Elapsed: {0:hh:mm:ss:fff}", e.SignalTime);
        }
    }
}
