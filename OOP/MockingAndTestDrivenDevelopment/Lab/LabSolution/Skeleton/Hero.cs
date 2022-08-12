using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class Hero
    {
        public IWeapon Weapon { get; private set; }

        public int XP { get; private set; }

        public Hero(IWeapon weapon)
        {
            this.Weapon = weapon;
            this.XP = 0;
        }

        public void Attack(ITarget target)
        {
            Weapon.Attack(target);

            if (target.IsDead())
            {
                XP += target.GiveExperience();
            }
        }
    }
}
