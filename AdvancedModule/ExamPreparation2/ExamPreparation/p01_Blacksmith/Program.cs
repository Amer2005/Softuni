using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace p01_Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Dictionary<int, Sword> materialAndSword = new Dictionary<int, Sword>();
            //material count, total swords made, sword type

            materialAndSword.Add(70, new Sword(0, "Gladius")); //Gladius
            materialAndSword.Add(80, new Sword(0, "Shamshir")); //Shamshir
            materialAndSword.Add(90, new Sword(0, "Katana")); //Katana
            materialAndSword.Add(110, new Sword(0, "Sabre"));//Sabre
            materialAndSword.Add(150, new Sword(0, "Broadsword"));//Broadsword

            int totalNumberOfSwords = 0;

            while (true)
            {
                if (steel.Count == 0 || carbon.Count == 0)
                {
                    break;
                }

                int steelNow = steel.Dequeue();
                int carbonNow = carbon.Pop();

                int alloy = steelNow + carbonNow;

                if (materialAndSword.ContainsKey(alloy))
                {
                    materialAndSword[alloy].TotalMade++;
                    totalNumberOfSwords++;
                }
                else
                {
                    carbonNow += 5;

                    carbon.Push(carbonNow);
                }
            }

            if(totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            if(steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var materialSwordPair in materialAndSword.OrderBy(x => x.Value.Name))
            {
                Sword sword = materialSwordPair.Value;

                if (sword.TotalMade > 0)
                {
                    Console.WriteLine($"{sword.Name}: {sword.TotalMade}");
                }
            }
        }

        public class Sword
        {
            public Sword(int totalMade, string name)
            {
                TotalMade = totalMade;
                Name = name;
            }

            public int TotalMade { get; set; }

            public string Name { get; set; }
        }
    }
}
