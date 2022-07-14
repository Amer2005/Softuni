using p03_Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Core
{
    public interface IEngine
    {
        void Run(List<BaseHero> heroes, int bossPower);
    }
}
