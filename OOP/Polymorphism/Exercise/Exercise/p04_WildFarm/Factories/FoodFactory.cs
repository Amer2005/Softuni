using p04_WildFarm.Factories.Interfaces;
using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            switch (type)
            {
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    throw new InvalidOperationException("food not found");
            }
        }
    }
}
