using System;
using System.Threading.Tasks;
using TMS_DotNet_Group_4_CashManager.Services;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    internal class Cash
    {
        public decimal Income { get; set; }

        public Cash(int number)
        {
            var cashInfo = new CashInfo
            {
                Number = number,
                Speed = Helper.GetRandomValue(400, 1000),
            };

            var result = Task<decimal>.Factory.StartNew(() => Run(cashInfo));
            Income = result.Result;

            Console.WriteLine($"Cash number: {number}, Income: {Income}$");
        }

        private decimal Run(object cashInfoObject)
        {
            var cashInfo = cashInfoObject as CashInfo;
            var incomeByCash = 0M;

            foreach (var customer in cashInfo.Customers)
            {
                var incomeByCustomer = 0M;

                decimal discount = customer.discountBalance;
                
                foreach (var product in customer.Cart.inventory.Products)
                {
                    incomeByCustomer += product.Price;
                }

                var task = Task.Delay(cashInfo.Speed);
                task.Wait();
                
                if (incomeByCustomer <= 0)
                {
                    discount = 0;
                }

                var discountIncome = (discount * incomeByCustomer) / 100;
                
                var totalPrice = incomeByCustomer - discountIncome;
                Console.WriteLine($"Cash number: {cashInfo.Number}|| "
                    + $"Price - {incomeByCustomer}$|| " 
                    + $"Discount - {discount}% - {discountIncome}$|| "
                    + $"Total - {totalPrice}");

                incomeByCash += totalPrice;

                if (DateTime.Now.ToString("T") == Shift.GetEndTime().ToString("T"))
                {
                    break;
                }
            }

            return incomeByCash;
        }
    }
}