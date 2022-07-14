using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using p03_Raiding.Models;

namespace p03_Raiding.Core
{
    public class Engine : IEngine
    {
        public void Run(List<BaseHero> heroes, int bossPower)
        {
            if (heroes.Count == 0)
            {
                Console.WriteLine("Defeat...");

                return;
            }

            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine(heroes[i].CastAbility());
            }

            int powerSum = heroes.Sum(x => x.Power);

            Console.WriteLine(powerSum >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
