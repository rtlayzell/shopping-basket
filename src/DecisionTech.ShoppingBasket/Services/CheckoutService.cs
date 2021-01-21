using System.Linq;

namespace DecisionTech.ShoppingBasket.Services
{
    public class CheckoutService : ICheckoutService
    {
        public decimal CalculateTotal(Basket basket)
        {
            return basket.Select(x => x.Cost).Sum();
        }
    }
}
