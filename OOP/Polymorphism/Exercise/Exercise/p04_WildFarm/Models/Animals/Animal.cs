using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using p04_WildFarm;
using p04_WildFarm.Exceptions;

namespace p04_WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
        
        protected abstract IReadOnlyCollection<Type> PrefferedFoods { get; }

        protected abstract double WeightIncrease { get; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new FoodNotEatenByAnimalException
                    (String.Format(ExceptionMessages.FoodNotEatenByAnimal, 
                                    this.GetType().Name, food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;

            this.Weight += food.Quantity * WeightIncrease;
        }
    }
}
