using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DecisionTech.ShoppingBasket
{
    public class Basket : IEnumerable<Product>
    {
        private readonly List<Product> _products;

        public Basket()
        {
            _products = new List<Product>();
        }

        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _products.Add(product);
        }

        public IEnumerator<Product> GetEnumerator() 
            => _products.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => ((IEnumerable<Product>)this).GetEnumerator();
    }
}
