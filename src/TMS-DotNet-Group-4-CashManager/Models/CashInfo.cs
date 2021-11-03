using System.Collections.Generic;
using TMS_DotNet_Group_4_CashManager.Services;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    public class CashInfo
    {
        public int Number { get; set; }

        public int Speed { get; set; }

        public IEnumerable<Customer> Customers { get; set; } = Helper.GetRandomCustomers();

        public decimal Income { get; set; }
    }
}