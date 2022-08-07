using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int damage = 25;

        public Mace(string name, int durabilty)
            : base(name, durabilty)
        {

        }

        public override int DoDamage()
        {
            return DoDamage(damage);
        }
    }
}
