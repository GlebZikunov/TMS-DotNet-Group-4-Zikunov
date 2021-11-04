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

                var cashCount = 5;
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
    }
}
