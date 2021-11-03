using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DotNet_Group_4_CashManager.Services;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    public class Inventory
    {
        public static Helper helper = new Helper();

        /// <summary>
        /// Maximum random value depending on the selected inventory.
        /// </summary>

        public IEnumerable<Product> Products { get; set; } = helper.GetRandomProducts();
    }
}