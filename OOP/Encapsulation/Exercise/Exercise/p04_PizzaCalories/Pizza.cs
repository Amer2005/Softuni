using System;
using System.Collections.Generic;
using System.Text;

namespace p04_PizzaCalories
{
    public class Pizza
    {
        private string name;

        private List<Topping> toppings;

        private Dough dough;

        public Pizza(string name)
        {
            toppings = new List<Topping>();
            this.Name = name;
        }

        public int NumberOfToppings => toppings.Count;

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough 
        { 
            get => dough; 
            set => dough = value; 
        }

        public decimal Calories => GetCalories();

        private decimal GetCalories()
        {
            decimal calories = Dough.Calories;

            foreach (var topping in toppings)
            {
                calories += topping.Calories;
            }

            return calories;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
    }
}
