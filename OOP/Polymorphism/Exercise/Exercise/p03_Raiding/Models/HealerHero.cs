using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Models
{
    public abstract class HealerHero : BaseHero
    {
        protected HealerHero(string name, int power) : base(name, power)
        {
        }

        public override sealed string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
