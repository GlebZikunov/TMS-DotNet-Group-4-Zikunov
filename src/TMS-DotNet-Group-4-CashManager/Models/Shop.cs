using System;
using System.Threading;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    internal class Shop
    {
        public void Start()
        {
            Console.Write("Cash count: ");
            var cashCount = int.Parse(Console.ReadLine());

            var commonIncome = 0M;

            for (int i = 1; i <= cashCount; i++)
            {
                Console.WriteLine($"{new string('-', 20)}");
                var cash = new Cash(i);
                Console.WriteLine($"{new string('-', 20)}");
                Console.WriteLine();

                commonIncome += cash.Income;
            }
            Console.WriteLine($"Total income: {commonIncome}$");
        }
    }
}
