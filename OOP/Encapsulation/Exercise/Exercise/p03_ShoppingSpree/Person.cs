using System;
using System.Collections.Generic;
using System.Text;

namespace p03_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException($"Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;

                bagOfProducts.Add(product);

                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }
        
        public IReadOnlyCollection<Product> BagOfProducts
        {
            get => bagOfProducts.AsReadOnly();
        }

        public override string ToString()
        {
            if (this.BagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {String.Join(", ", this.BagOfProducts)}";
        }
    }
}
