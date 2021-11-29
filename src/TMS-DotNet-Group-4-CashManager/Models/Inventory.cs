using System.Collections.Generic;
using TMS_DotNet_Group_4_CashManager.Services;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    public class Inventory
    {
        public static Helper helper = new Helper();

        public IEnumerable<Product> Products { get; set; } = helper.GetRandomProducts();
    }
}