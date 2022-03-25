using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();

            string input;

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] splittedInput = input.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                string city = splittedInput[0];
                int population = int.Parse(splittedInput[1]);
                int gold = int.Parse(splittedInput[2]);

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new City(gold, population));
                }
                else
                {
                    cities[city].Gold += gold;
                    cities[city].Population += population;
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedInput = input.Split(new string[] { "=>" }, 
                    StringSplitOptions.RemoveEmptyEntries);

                string action = splittedInput[0];
                string city = splittedInput[1];

                if(action == "Plunder")
                {
                    int populationKilled = int.Parse(splittedInput[2]);
                    int goldTaken = int.Parse(splittedInput[3]);

                    cities[city].Gold -= goldTaken;
                    cities[city].Population -= populationKilled;

                    Console.WriteLine($"{city} plundered! {goldTaken} gold stolen, {populationKilled} citizens killed.");

                    if(cities[city].Gold <= 0 || cities[city].Population <= 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");
                        cities.Remove(city);
                    }
                }
                else if (action == "Prosper")
                {
                    int goldAdded = int.Parse(splittedInput[2]);

                    if (goldAdded < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    cities[city].Gold += goldAdded;

                    Console.WriteLine($"{goldAdded} gold added to the city treasury. {city} now has {cities[city].Gold} gold.");
                }
            }

            if (cities.Count > 0)
            {

                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (KeyValuePair<string, City> cityNamePair in cities)
                {
                    Console.WriteLine($"{cityNamePair.Key} -> Population: {cityNamePair.Value.Population} citizens, Gold: {cityNamePair.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    public class City
    {
        public City(int gold, int population)
        {
            Gold = gold;
            Population = population;
        }

        public int Gold { get; set; }

        public int Population { get; set; }
    }
}
