using p04_WildFarm.Models.Animals;
using p04_WildFarm.Models.Animals.Bird;
using p04_WildFarm.Models.Animals.Mammal;
using p04_WildFarm.Models.Animals.Mammal.Feline;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, params string[] otherParams);
    }
}
