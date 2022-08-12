using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int InitialSize = 3;
        private const int SizeIncrease = 3;
        public FreshwaterFish(string name, string species, decimal price)
            :base(name, species, price)
        {
            base.Size = InitialSize;
        }

        public override void Eat()
        {
            base.Size += SizeIncrease;
        }
    }
}
