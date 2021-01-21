namespace DecisionTech.ShoppingBasket.Services
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(Basket basket);
    }
}
