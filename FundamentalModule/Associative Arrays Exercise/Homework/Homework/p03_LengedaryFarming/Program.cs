using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_LengedaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();

            string[] legendaryMaterials = new string[] { "shards", "motes", "fragments" };

            string winner = string.Empty;

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(' ');

                for (int i = 0; i < inputArgs.Length - 1; i += 2)
                {
                    int quantity = int.Parse(inputArgs[i]);
                    string material = inputArgs[i + 1].ToLower();

                    if (materials.ContainsKey(material))
                    {
                        materials[material] += quantity;
                    }
                    else
                    {
                        materials.Add(material, quantity);
                    }

                    if (winner != string.Empty)
                    {
                        continue;
                    }

                    if (material == "shards" && materials[material] >= 250)
                    {
                        winner = "Shadowmourne";

                        materials[material] -= 250;

                        break;
                    }
                    else if (material == "fragments" && materials[material] >= 250)
                    {
                        winner = "Valanyr";

                        materials[material] -= 250;

                        break;
                    }
                    else if (material == "motes" && materials[material] >= 250)
                    {
                        winner = "Dragonwrath";

                        materials[material] -= 250;

                        break;
                    }
                }

                if (winner != string.Empty)
                {
                    break;
                }
            }

            Console.WriteLine($"{winner} obtained!");

            foreach(string material in legendaryMaterials)
            {
                if (materials.ContainsKey(material))
                {
                    Console.WriteLine($"{material}: {materials[material]}");
                }
                else
                {
                    Console.WriteLine($"{material}: 0");
                }
            }

            foreach (var materialQuantityPair in materials)
            {
                if(legendaryMaterials.Contains(materialQuantityPair.Key))
                {
                    continue;
                }

                Console.WriteLine($"{materialQuantityPair.Key}: {materialQuantityPair.Value}");
            }
        }
    }
}
