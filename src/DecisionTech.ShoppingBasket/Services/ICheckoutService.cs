using System.Text;

namespace DecisionTech.ShoppingBasket.Services
{
    public interface ICheckoutService
    {
        decimal CalculateTotal(Basket basket);
    }
}
