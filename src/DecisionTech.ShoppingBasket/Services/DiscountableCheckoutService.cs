using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.ShoppingBasket.Services
{
    public class DiscountableCheckoutService : ICheckoutService
    {
        private readonly ICheckoutService _checkout;
        private readonly List<IDiscountCalculator> _discounts;

        public DiscountableCheckoutService(ICheckoutService checkout, IEnumerable<IDiscountCalculator> discounts)
        {
            _checkout = checkout ?? throw new ArgumentNullException(nameof(checkout));
            _discounts = discounts?.ToList() ?? throw new ArgumentNullException(nameof(discounts));
        }

        public decimal CalculateTotal(Basket basket)
        {
            return _checkout.CalculateTotal(basket)
                 - _discounts.Sum(x => x.CalculateDiscount(basket));
        }
    }
}
