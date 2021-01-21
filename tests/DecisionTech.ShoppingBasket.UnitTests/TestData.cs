namespace DecisionTech.ShoppingBasket.UnitTests
{
    public static class TestData
    {
        public static Product[] Products { get; }

        public static Product Butter { get; }

        public static Product Bread { get; }

        public static Product Milk { get; }


        static TestData()
        {
            // We'll just use an in memory collection to represent the products.
            // ordinarily we would pull this stuff from the database, and use Entity Id's
            // however the object reference will do for now.
            Products = new[]
            {
                Butter = new Product("Butter", 0.80m),
                Milk = new Product("Milk", 1.15m),
                Bread = new Product("Bread", 1.00m),
            };
        }
    }
}
