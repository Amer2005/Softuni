using System;
using System.Collections.Generic;
using System.Text;

namespace p04_WildFarm.Models.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get;}
    }
}
