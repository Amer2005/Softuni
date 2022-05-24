using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());

            Dictionary<string, Continent> ContinentsAndCountries = new Dictionary<string, Continent>();

            for (int i = 0; i < numberOfCities; i++)
            {
                string[] inputArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string continent = inputArgs[0];
                string country = inputArgs[1];
                string city = inputArgs[2];

                if (ContinentsAndCountries.ContainsKey(continent))
                {
                    if(ContinentsAndCountries[continent].Countries.ContainsKey(country))
                    {
                        ContinentsAndCountries[continent].Countries[country].Cities.Add(city);
                    }
                    else
                    {
                        ContinentsAndCountries[continent].Countries.Add(country, new Country(city));
                    }
                }
                else
                {
                    ContinentsAndCountries.Add(continent, new Continent(country, city));
                }
            }

            foreach (var continentCountriesPair in ContinentsAndCountries)
            {
                Console.WriteLine($"{continentCountriesPair.Key}:");

                foreach (var countryCitiesPair in continentCountriesPair.Value.Countries)
                {
                    Console.WriteLine($"  {countryCitiesPair.Key} -> {string.Join(", ", countryCitiesPair.Value.Cities)}");
                }
            }
        }

        public class Continent
        {
            public Continent()
            {
                Countries = new Dictionary<string, Country>();
            }

            public Continent(string country, string city)
            {
                Countries = new Dictionary<string, Country>();

                Countries.Add(country, new Country(city));
            }

            public Dictionary<string, Country> Countries { get; set; }
        }

        public class Country
        {
            public Country()
            {
                Cities = new List<string>();
            }

            public Country(string city)
            {
                Cities = new List<string> { city };
            }

            public List<string> Cities { get; set; }
        }
    }
}
