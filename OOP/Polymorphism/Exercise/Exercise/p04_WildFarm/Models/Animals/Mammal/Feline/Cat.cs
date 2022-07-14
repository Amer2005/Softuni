using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Models.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoods =>
           new List<Type> { typeof(Meat), typeof(Vegetable) }.AsReadOnly();

        protected override double WeightIncrease => 0.3;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
