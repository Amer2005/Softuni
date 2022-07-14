using p03_Raiding.Factories.Interfaces;
using p03_Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Factories
{
    internal class HeroFactory : IHeroFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
