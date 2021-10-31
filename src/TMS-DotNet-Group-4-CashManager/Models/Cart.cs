using System.Collections.Generic;
using TMS_DotNet_Group_4_CashManager.Services;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    public class Cart
    {
        public IEnumerable<Product> Products { get; set; } = Helper.GetRandomProducts();
    }
}
