using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        public Food CreateFood(string type, int quantity);
    }
}
