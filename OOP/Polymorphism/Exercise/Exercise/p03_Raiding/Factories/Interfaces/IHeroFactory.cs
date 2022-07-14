using p03_Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        BaseHero CreateHero(string type, string name);
    }
}
