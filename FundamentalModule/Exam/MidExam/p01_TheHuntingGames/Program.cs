using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_TheHuntingGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int numberOfPlayers = int.Parse(Console.ReadLine());

            decimal energy = decimal.Parse(Console.ReadLine());

            decimal waterPerDay = decimal.Parse(Console.ReadLine());
            decimal foodPerDay = decimal.Parse(Console.ReadLine());

            decimal totalWater = waterPerDay * numberOfPlayers * numberOfDays;
            decimal totalFood = foodPerDay * numberOfPlayers * numberOfDays;

            int dayNow = 1;

            while (energy > 0)
            {
                decimal energyLost = decimal.Parse(Console.ReadLine());

                energy -= energyLost;

                if (energy <= 0)
                {
                    break;
                }

                if (dayNow % 2 == 0)
                {
                    energy = energy * 1.05m;
                    totalWater = totalWater * 0.7m;
                }
                if (dayNow % 3 == 0)
                {
                    energy = energy * 1.1m;
                    totalFood -= totalFood / numberOfPlayers;
                }

                dayNow++;

                if (dayNow > numberOfDays)
                {
                    break;
                }
            }

            if (energy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
        }
    }
}
