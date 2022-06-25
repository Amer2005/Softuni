using System;
using System.Collections.Generic;
using System.Linq;

namespace p01_TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> whiteTiles = new List<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)); // last

            List<int> greyTiles = new List<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)); // first

            Dictionary<int, int> kitchen = new Dictionary<int, int>();

            kitchen.Add(-1, 0); // Floor
            kitchen.Add(40, 0); //Sink 
            kitchen.Add(50, 0); //Oven
            kitchen.Add(60, 0); //Countertop
            kitchen.Add(70, 0); //Wall

            while (true)
            {
                if (whiteTiles.Count == 0)
                {
                    break;
                }

                if (greyTiles.Count == 0)
                {
                    break;
                }

                int greyTile = greyTiles[0];

                greyTiles.RemoveAt(0);

                int whiteTile = whiteTiles[whiteTiles.Count - 1];

                whiteTiles.RemoveAt(whiteTiles.Count - 1);

                if (whiteTile == greyTile)
                {
                    int newTile = whiteTile + greyTile;

                    if (kitchen.ContainsKey(newTile))
                    {
                        kitchen[newTile]++;
                    }
                    else
                    {
                        kitchen[-1]++;
                    }
                }
                else
                {
                    whiteTiles.Add(whiteTile / 2);
                    greyTiles.Add(greyTile);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                whiteTiles.Reverse();
                Console.WriteLine($"White tiles left: {String.Join(", ",whiteTiles)}");
            }




            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                //greyTiles.Reverse();

                Console.WriteLine($"Grey tiles left: {String.Join(", ", greyTiles)}");
            }

            foreach (var MaterialandCountPair in kitchen.OrderByDescending(x => x.Value).ThenBy(x => GetName(x.Key)))
            {
                if (MaterialandCountPair.Value == 0)
                {
                    continue;
                }

                Console.WriteLine($"{GetName(MaterialandCountPair.Key)}: {MaterialandCountPair.Value}");
            }
        }

        static string GetName(int material)
        {
            switch (material)
            {
                case 40:
                    return "Sink";
                case 50:
                    return "Oven";
                case 60:
                    return "Countertop";
                case 70:
                    return "Wall";
                default:
                    return "Floor";
            }
        }

    }
}
