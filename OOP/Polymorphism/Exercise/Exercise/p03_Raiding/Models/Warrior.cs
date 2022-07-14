using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Models
{
    public class Warrior : DamageHero
    {
        private const int WarriorPower = 100;

        public Warrior(string name) : base(name, WarriorPower)
        {
        }
    }
}
