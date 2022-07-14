using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Models.Animals.Mammal
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoods =>
           new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightIncrease => 0.4;

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
