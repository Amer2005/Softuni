using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Models
{
    public class Rogue : DamageHero
    {
        private const int RoguePower = 80;

        public Rogue(string name) : base(name, RoguePower)
        {
        }
    }
}
