using p04_WildFarm.Factories.Interfaces;
using p04_WildFarm.Models.Animals;
using p04_WildFarm.Models.Animals.Bird;
using p04_WildFarm.Models.Animals.Mammal;
using p04_WildFarm.Models.Animals.Mammal.Feline;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, params string[] otherParams)
        {
            switch (type)
            {
                case "Hen":
                    return new Hen(name, weight, double.Parse(otherParams[0]));
                case "Owl":
                    return new Owl(name, weight, double.Parse(otherParams[0]));
                case "Cat":
                    return new Cat(name, weight, otherParams[0], otherParams[1]);
                case "Tiger":
                    return new Tiger(name, weight, otherParams[0], otherParams[1]);
                case "Dog":
                    return new Dog(name, weight, otherParams[0]);
                case "Mouse":
                    return new Mouse(name, weight, otherParams[0]);
                default:
                    throw new InvalidOperationException("Invalid animal!");
            }
        }
    }
}
