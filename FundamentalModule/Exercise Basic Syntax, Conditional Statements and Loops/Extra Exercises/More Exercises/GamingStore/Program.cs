using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore
{
    internal class Program
    {

        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());

            double moneySpent = 0;

            string input = Console.ReadLine();

            while(input != "Game Time")
            {
                if(money == 0)
                {
                    break;
                }

                double gamePrice = GetGamePrice(input);

                if (gamePrice == -1)
                {
                    Console.WriteLine("Not Found");
                    input = Console.ReadLine();
                    continue;
                }

                if (gamePrice > money)
                {
                    Console.WriteLine("Too Expensive");
                    input = Console.ReadLine();
                    continue;
                }

                money -= gamePrice;

                moneySpent += gamePrice;

                Console.WriteLine($"Bought {input}");

                input = Console.ReadLine();
            }

            if (money == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${money:f2}");
            }
        }

        private static double GetGamePrice(string name)
        {
            switch (name)
            {
                case "OutFall 4":
                    return 39.99;
                case "CS: OG":
                    return 15.99;
                case "Zplinter Zell":
                    return 19.99;
                case "Honored 2":
                    return 59.99;
                case "RoverWatch":
                    return 29.99;
                case "RoverWatch Origins Edition":
                    return 39.99;
                default:
                    return -1;
            }
        }
    }
}
