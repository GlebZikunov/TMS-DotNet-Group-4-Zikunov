using System;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    internal class Shop
    {
        public void Start()
        {
            var stopword = false;

            while (!stopword)
            {
                var shift = new Shift();

                shift.InputTime();
                shift.Start();

                //Console.Write("Cash count: ");
                var cashCount = 5;//int.Parse(Console.ReadLine());

                var commonIncome = 0M;

                for (int i = 1; i <= cashCount; i++)
                {
                    Console.WriteLine($"{new string('-', 20)}");
                    var cash = new Cash(i);
                    Console.WriteLine($"{new string('-', 20)}");
                    Console.WriteLine();

                    commonIncome += cash.Income;

                    if (DateTime.Now.ToString("T") == Shift.GetEndTime().ToString("T"))
                    {
                        break;
                    }
                }
                
                Console.WriteLine($"Total income: {commonIncome}$");
                shift.End();

                stopword = Shift.StopInput();
                Console.Clear();
            }
        }

        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
        }
    }
}
