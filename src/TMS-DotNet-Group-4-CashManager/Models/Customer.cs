using TMS_DotNet_Group_4_CashManager.Services;

namespace TMS_DotNet_Group_4_CashManager.Models
{
    public class Customer
    {
        public decimal Balance { get; set; } = Helper.GetRandomValue(0, 500);
        /// <summary>
        /// Скидка клиенту.
        /// </summary>
        public int discountBalance { get; set; } = Helper.GetRandomValue(1, 10);

        public Cart Cart { get; set; } = new Cart();
    }
}
