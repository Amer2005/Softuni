using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Program
    {
        private static double GetItemPrice(string item)
        {
            switch (item)
            {
                case "Nuts":
                    return 2;
                case "Water":
                    return 0.7;
                case "Crisps":
                    return 1.5;
                case "Soda":
                    return 0.8;
                case "Coke":
                    return 1;
                default:
                    break;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            string coinInput = Console.ReadLine();

            double money = 0;

            while (coinInput != "Start")
            {
                double coin = double.Parse(coinInput);

                if (coin != 0.1 && coin != 0.2 && coin != 0.5 && coin != 1 && coin != 2)
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    money += coin;
                }

                coinInput = Console.ReadLine();
            }

            string itemInput = Console.ReadLine();

            while (itemInput != "End")
            {
                double itemPrice = GetItemPrice(itemInput);

                if (itemPrice == -1)
                {
                    Console.WriteLine("Invalid product");

                    itemInput = Console.ReadLine();

                    continue;
                }
                
                if (itemPrice <= money)
                {
                    money -= itemPrice;

                    Console.WriteLine($"Purchased {char.ToLower(itemInput[0]) + itemInput.Substring(1)}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                itemInput = Console.ReadLine();
            }

            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
