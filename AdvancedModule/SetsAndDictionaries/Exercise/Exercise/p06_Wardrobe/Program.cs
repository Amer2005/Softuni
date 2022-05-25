using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> ColorColthesAndCount = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = inputArgs[0];

                string[] clothes = inputArgs[1].Split(',');

                if (!ColorColthesAndCount.ContainsKey(color))
                {
                    ColorColthesAndCount.Add(color, new Dictionary<string, int>());
                }

                foreach (var clothing in clothes)
                {
                    if (ColorColthesAndCount[color].ContainsKey(clothing))
                    {
                        ColorColthesAndCount[color][clothing]++;
                    }
                    else
                    {
                        ColorColthesAndCount[color].Add(clothing, 1);
                    }
                }
            }

            string[] searchClothingArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string searchColor = searchClothingArgs[0];
            string searchClothing = searchClothingArgs[1];

            foreach (var ColorColthesAndCountPair in ColorColthesAndCount)
            {
                Console.WriteLine($"{ColorColthesAndCountPair.Key} clothes:");

                foreach (var clothesCountPair in ColorColthesAndCountPair.Value)
                {
                    Console.Write($"* {clothesCountPair.Key} - {clothesCountPair.Value}");

                    if (ColorColthesAndCountPair.Key == searchColor && clothesCountPair.Key == searchClothing)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
