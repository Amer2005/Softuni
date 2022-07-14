using p03_Raiding.Core;
using p03_Raiding.Factories;
using p03_Raiding.Factories.Interfaces;
using p03_Raiding.Models;
using System;
using System.Collections.Generic;

namespace p03_Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            IEngine engine = new Engine();

            IHeroFactory heroFactory = new HeroFactory();

            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    heroes.Add(heroFactory.CreateHero(type, name));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            engine.Run(heroes, bossPower);
        }
    }
}
