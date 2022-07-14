using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; protected set; }

        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
