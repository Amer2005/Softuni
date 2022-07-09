using System;
using System.Collections.Generic;
using System.Text;

namespace p04_PizzaCalories
{
    public class Topping
    {
        private string type;
        private decimal grams;

        public Topping(string type, decimal grams)
        {
            this.type = type;
            this.grams = grams;

            if (GetToppingMultiplier() == -1)
            {
                throw new ArgumentException($"Cannot place {this.type} on top of your pizza."); 
            }

            if (this.grams < 1 || this.grams > 50)
            {
                throw new ArgumentException($"{this.type} weight should be in the range[1..50].");
            }
        }

        public decimal Calories => GetToppingCalories();

        private decimal GetToppingCalories()
        {
            return 2 * grams * GetToppingMultiplier();
        }

        private decimal GetToppingMultiplier()
        {
            string loweredType = type.ToLower();

            if(loweredType == "meat")
            {
                return 1.2m;
            }
            else if (loweredType == "veggies")
            {
                return 0.8m;
            }
            else if (loweredType == "cheese")
            {
                return 1.1m;
            }
            else if (loweredType == "sauce")
            {
                return 0.9m;
            }

            return -1;
        }
    }
}
