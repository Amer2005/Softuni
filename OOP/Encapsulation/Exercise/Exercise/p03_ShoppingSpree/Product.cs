using System;
using System.Collections.Generic;
using System.Text;

namespace p03_ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name 
        { 
            get => name; 
            private set
            {
                name = value;
            }
        }

        public decimal Cost 
        {
            get => cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }
                else
                {
                    cost = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
