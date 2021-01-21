using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.ShoppingBasket.Services
{
    public class PercentageDiscountCalculator : IDiscountCalculator
    {
        private readonly List<Product> _requirements;
        private readonly Product _discountedProduct;
        private readonly double _percentage;

        public PercentageDiscountCalculator(double p, Product discountedProduct, IEnumerable<Product> requirements)
        {
            _discountedProduct = discountedProduct ?? throw new ArgumentNullException(nameof(discountedProduct));
            _requirements = requirements?.ToList() ?? throw new ArgumentNullException(nameof(requirements));
            _percentage = p;
        }

        public decimal CalculateDiscount(Basket basket)
        {
            var requires = _requirements.ToList();
            requires.Add(_discountedProduct);

            var discount = 0.0m;
            foreach (var item in basket)
            {
                requires.Remove(item);
                if (!requires.Any())
                {
                    discount += _discountedProduct.Cost * (decimal)_percentage;
                    requires = _requirements.ToList();
                }
            }

            return discount;
        }
    }
}
