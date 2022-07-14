using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Models.Animals.Bird
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoods => new List<Type> {typeof(Meat)}.AsReadOnly();

        protected override double WeightIncrease => 0.25;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
