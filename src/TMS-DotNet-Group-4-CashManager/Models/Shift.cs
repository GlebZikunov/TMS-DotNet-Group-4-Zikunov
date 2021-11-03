using System;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    public class Shift
    {
        public static DateTime StartTime;

        public static DateTime EndTime;

        public void Start()
        {
            StartTime = DateTime.Now;
            Console.WriteLine($"\nShift started at {StartTime}\n");
        }

        public void End()
        {
            Console.WriteLine($"\nShift ended at {EndTime}\n");
        }

        public DateTime InputTime()
        {
            string UserInput;

            do
            {
                Console.WriteLine("Enter end of the shift (HH:mm:ss):");
                UserInput = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(UserInput, "HH:mm:ss",
            null, System.Globalization.DateTimeStyles.AssumeLocal, out EndTime));

            Console.Clear();
            return EndTime;
        }

        public static DateTime GetEndTime()
        {
            return EndTime;
        }

        public static bool StopInput()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("\nDo you want to close grocery shop? (Press 'Y' or 'y'): ");
            Console.ResetColor();

            var key = Console.ReadKey().Key;
            Console.WriteLine();
         
            return key == ConsoleKey.Y;
        }
    }
}
