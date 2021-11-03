using System;
using System.Linq;
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
                /// <summary>
                /// Скидка клиенту.
                /// </summary>
                decimal discount = customer.discountBalance; // Discount to customer
                /*customer.Cart.Products = customer.Cart.Products.OrderByDescending(product => product.Price);

                while (true)
                {
                    var cartSum = customer.Cart.Products.Sum(product => product.Price);
                    if (customer.Balance >= cartSum)
                    {
                        break;
                    }

                    customer.Cart.Products = customer.Cart.Products.Skip(1);
                }*/

                foreach (var product in customer.Cart.inventory.Products)
                {
                    incomeByCustomer += product.Price;
                }

                var task = Task.Delay(cashInfo.Speed);
                task.Wait();
                /// <summary>
                /// Скидка равна 0, если сумма равна 0.
                /// </summary>
                if (incomeByCustomer <= 0)
                {
                    discount = 0;
                }
                /// <summary>
                /// Считаем скидку от основной суммы.
                /// </summary>
                var discountIncome = (discount * incomeByCustomer) / 100;
                /// <summary>
                /// Итоговая цена, от основной суммы отнимаем скидку.
                /// </summary>
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