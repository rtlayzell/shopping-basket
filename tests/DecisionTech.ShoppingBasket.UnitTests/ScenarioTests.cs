using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecisionTech.ShoppingBasket.Services;
using Xunit;

namespace DecisionTech.ShoppingBasket.UnitTests
{
    public class ScenarioTests
    {
        [Fact]
        public void Scenario1()
        {
            var basket = new Basket();
            var checkout = new CheckoutService();

            basket.Add(TestData.Bread);
            basket.Add(TestData.Butter);
            basket.Add(TestData.Milk);

            Assert.Equal(2.95m, checkout.CalculateTotal(basket));
        }

        [Fact]
        public void Scenario2()
        {
            var basket = new Basket();
            var checkout = new DiscountableCheckoutService(
                new CheckoutService(),
                new[] { 
                    new PercentageDiscountCalculator(0.5, Enumerable.Repeat(TestData.Butter, 2), TestData.Bread), 
                });

            basket.Add(TestData.Butter);
            basket.Add(TestData.Butter);

            basket.Add(TestData.Bread);
            basket.Add(TestData.Bread);

            Assert.Equal(3.10m, checkout.CalculateTotal(basket));
        }

        [Fact]
        public void Scenario3()
        {
            var basket = new Basket();
            var checkout = new DiscountableCheckoutService(
                new CheckoutService(),
                new[] {
                    new PercentageDiscountCalculator(0.5, Enumerable.Repeat(TestData.Butter, 2), TestData.Bread),
                    new PercentageDiscountCalculator(1.0, Enumerable.Repeat(TestData.Milk, 3), TestData.Milk),
                });

            basket.Add(TestData.Milk);
            basket.Add(TestData.Milk);
            basket.Add(TestData.Milk);
            basket.Add(TestData.Milk);

            Assert.Equal(3.45m, checkout.CalculateTotal(basket));
        }
    }
}
