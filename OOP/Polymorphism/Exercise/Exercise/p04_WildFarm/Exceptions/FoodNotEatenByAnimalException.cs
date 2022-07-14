using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Exceptions
{
    public class FoodNotEatenByAnimalException : Exception
    {
        public FoodNotEatenByAnimalException(string message)
            : base(message)
        {

        }
    }
}
