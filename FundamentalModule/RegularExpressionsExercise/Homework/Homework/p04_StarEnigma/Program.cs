using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p04_StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> specialSymbols = new List<char> { 's', 't', 'a', 'r' };

            int numberOfMessages = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numberOfMessages; i++)
            {
                string encryptedMessage = Console.ReadLine();

                string decryptedMessage = DecryptMessage(encryptedMessage, specialSymbols);

                Regex regex = new Regex(@"^[^@\-!:>]*@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>[0-9]+)[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldierCount>[0-9]+)[^@\-!:>]*$");
                
                if(!regex.IsMatch(decryptedMessage))
                {
                    continue;
                }
                
                Match match = regex.Match(decryptedMessage);

                string planet = match.Groups["planet"].Value;
                int population = int.Parse(match.Groups["population"].Value);
                string attackType = match.Groups["attackType"].Value;
                int soldierCount = int.Parse(match.Groups["soldierCount"].Value);

                if (attackType == "A")
                {
                    attackedPlanets.Add(planet);
                }
                else
                {
                    destroyedPlanets.Add(planet);
                }
            }

            attackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        static string DecryptMessage(string encryptedMessage, List<char> specialSymbols)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            int numberOfSpecialSymbols = encryptedMessage.ToLower().ToCharArray().Count(x => specialSymbols.Contains(x));

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                decryptedMessage.Append((char)(encryptedMessage[i] - numberOfSpecialSymbols));
            }

            return decryptedMessage.ToString();
        }
    }
}
