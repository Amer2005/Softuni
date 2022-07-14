using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Models
{
    public abstract class DamageHero : BaseHero
    {
        protected DamageHero(string name, int power) : base(name, power)
        {
        }

        public override sealed string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
