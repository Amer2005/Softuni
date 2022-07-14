using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Models
{
    public class Paladin : HealerHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) : base(name, PaladinPower)
        {
        }
    }
}
