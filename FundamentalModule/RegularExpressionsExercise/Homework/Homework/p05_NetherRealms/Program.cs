using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p05_NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> demons = Console.ReadLine().Split(new String[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            demons = demons.OrderBy(x => x).ToList();

            foreach (var demon in demons)
            {
                double damage = GetDemonDamage(demon);
                int health = GetDemonHealth(demon);

                Console.WriteLine($"{demon} - {health} health, {damage:f2} damage");
            }
        }

        static double GetDemonDamage(string demon)
        {
            //[-+]?[0-9]+(.[0-9]+)?
            Regex getNumbersRegex = new Regex(@"[-+]?[.\d]+");

            var matches = getNumbersRegex.Matches(demon);

            double damage = 0;

            foreach (Match match in matches)
            {
                double currentDamage = 0;

                if(!double.TryParse(match.Value, out currentDamage))
                {
                    continue;
                }

                damage += currentDamage;
            }

            int numberOfMultiplications = demon.ToCharArray().Count(x => x == '*');
            int numberOfDivisions = demon.ToCharArray().Count(x => x == '/');

            for (int i = 0; i < numberOfMultiplications; i++)
            {
                damage *= 2;
            }

            for (int i = 0; i < numberOfDivisions; i++)
            {
                damage /= 2;
            }

            return damage;
        }

        static int GetDemonHealth(string demon)
        {
            int health = 0;

            List<char> excludedChars = new List<char>{ '+', '-', '*', '/', '.' };

            for (int i = 0; i < demon.Length; i++)
            {
                if (char.IsDigit(demon[i]))
                {
                    continue;
                }

                if (excludedChars.Contains(demon[i]))
                {
                    continue;
                }

                health += demon[i];
            }

            return health;
        }
    }
}
