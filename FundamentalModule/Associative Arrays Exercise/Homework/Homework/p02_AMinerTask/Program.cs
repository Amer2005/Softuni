using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mineMaterials = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                string material = input;

                int quantity = int.Parse(Console.ReadLine());

                if(mineMaterials.ContainsKey(material))
                {
                    mineMaterials[material] += quantity;
                }
                else
                {
                    mineMaterials.Add(material, quantity);
                }
            }

            foreach (var keyValuePair in mineMaterials)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
