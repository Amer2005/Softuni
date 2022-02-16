using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if(index >= 0 && index < pokemons.Count)
                {
                    int pokemonNow = pokemons[index];
                    sum += pokemonNow;

                    pokemons.RemoveAt(index);

                    pokemons = MovePokemons(pokemons, pokemonNow);
                }
                else if (index < 0)
                {
                    int pokemonNow = pokemons[0];
                    sum += pokemonNow;

                    pokemons.RemoveAt(0);

                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);

                    pokemons = MovePokemons(pokemons, pokemonNow);
                }
                else
                {
                    int pokemonNow = pokemons[pokemons.Count - 1];
                    sum += pokemonNow;

                    pokemons.RemoveAt(pokemons.Count - 1); ;

                    pokemons.Insert(pokemons.Count, pokemons[0]);

                    pokemons = MovePokemons(pokemons, pokemonNow);
                }
            }

            Console.WriteLine(sum);
        }

        static List<int> MovePokemons(List<int> pokemons, int pokemon)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < pokemons.Count; i++)
            {
                int pokemonNow = pokemons[i];

                if (pokemonNow <= pokemon)
                {
                    pokemonNow += pokemon;
                }
                else
                {
                    pokemonNow -= pokemon;
                }

                result.Add(pokemonNow);
            }

            return result;
        }
    }
}
