using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine($"{CalculateTotalPrice(product, quantity):f2}");
        }

        static double CalculateTotalPrice(string product, int quantity)
        {
            double productPrice = 0;

            switch (product)
            {
                case "coffee":
                    productPrice = 1.5;
                    break;
                case "water":
                    productPrice = 1;
                    break;
                case "coke":
                    productPrice = 1.4;
                    break;
                case "snacks":
                    productPrice = 2;
                    break;
                default:
                    break;
            }

            return productPrice * quantity;
        }
    }
}
