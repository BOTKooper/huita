using System;
namespace Task01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(400, 170);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Title = "Custom title"; 
            Console.Beep();
            Console.WriteLine("Input your name:");
            string s = Console.ReadLine();
            Console.WriteLine(("Hello, {0}"), s);
            DateTime dt = DateTime.Now;
            Console.WriteLine("Today is {0}, {1:D2}.{2:D2}.{3:D2}", dt.DayOfWeek, dt.Day, dt.Month, dt.Year);
            Console.WriteLine("Time: {0:D2}:{1:D2}:{2:D2}", dt.Hour, dt.Minute, dt.Second);
            Console.WriteLine("To NewYear: {0} days",  ( ( new DateTime(dt.Year, 12, 31)  ).Date - dt.Date).TotalDays  );
        }
    }
}