using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] splittedInput = input.Split(' ');

                string name = splittedInput[0];
                string pokemon = splittedInput[1];
                string element = splittedInput[2];
                int health = int.Parse(splittedInput[3]);

                if (trainers.ContainsKey(name))
                {
                    trainers[name].Pokemons.Add(new Pokemon(pokemon, element, health));
                }
                else
                {
                    trainers.Add(name, new Trainer(name));

                    trainers[name].Pokemons.Add(new Pokemon(pokemon, element, health));
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string element = input;

                foreach (var nameTrainerPair in trainers)
                {
                    Trainer trainer = nameTrainerPair.Value;

                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
            }

            foreach (var nameTrainerPair in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine($"{nameTrainerPair.Value.Name} {nameTrainerPair.Value.NumberOfBadges} {nameTrainerPair.Value.Pokemons.Count}");
            }
        }
    }
}
