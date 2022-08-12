using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int InitialSize = 5;
        private const int SizeIncrease = 2;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            base.Size = InitialSize;
        }

        public override void Eat()
        {
            base.Size += SizeIncrease;
        }
    }
}
