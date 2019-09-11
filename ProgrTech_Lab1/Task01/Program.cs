using System;
namespace Task01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(400, 400);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "Custom title"; 
            Console.Beep();
            Console.WriteLine("Input your name:");
            string s = Console.ReadLine();
            Console.WriteLine(("Hello, {0}"), s);
            DateTime dt = DateTime.Now;
            Console.WriteLine("Today os {0}, {1:D2}.{2:D2}.{3:D2}", dt.DayOfWeek, dt.Day, dt.Month, dt.Year);
        }
    }
}