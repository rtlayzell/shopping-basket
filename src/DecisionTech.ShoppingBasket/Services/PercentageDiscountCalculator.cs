using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.ShoppingBasket.Services
{
    public class PercentageDiscountCalculator : IDiscountCalculator
    {
        private readonly List<Product> _requirements;
        private readonly Product _product;
        private readonly double _percentage;

        public PercentageDiscountCalculator(double p, IEnumerable<Product> requirements, Product product)
        {
            _requirements = requirements?.ToList() ?? throw new ArgumentNullException(nameof(requirements));
            _product = product ?? throw new ArgumentNullException(nameof(product));
            _percentage = p;

            _requirements.Add(product);
        }

        public decimal CalculateDiscount(Basket basket)
        {
            var requires = _requirements.ToList();
            requires.Add(_product);

            foreach (var item in basket)
                requires.Remove(item);

            return !requires.Any()
                 ? _product.Cost * (decimal)_percentage
                 : 0.0m;
        }
    }
}
