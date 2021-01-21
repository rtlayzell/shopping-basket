using System.Linq;

namespace DecisionTech.ShoppingBasket.Services
{
    public class CheckoutService : ICheckoutService
    {
        public decimal CalculateTotal(Basket basket)
        {
            return basket.Sum(x => x.Cost);
        }
    }
}
