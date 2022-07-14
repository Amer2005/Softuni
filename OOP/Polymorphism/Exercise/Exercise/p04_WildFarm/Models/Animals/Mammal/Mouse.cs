using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Models.Animals.Mammal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoods =>
           new List<Type> { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();

        protected override double WeightIncrease => 0.1;

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
