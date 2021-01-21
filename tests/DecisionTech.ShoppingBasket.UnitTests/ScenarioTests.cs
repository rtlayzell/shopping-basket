using System;
using System.Collections.Generic;
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
    }
}
