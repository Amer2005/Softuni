using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Models.Animals.Bird
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoods => 
            new List<Type> { typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable) }.AsReadOnly();

        protected override double WeightIncrease => 0.35;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
