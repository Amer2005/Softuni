using System;

namespace p01_ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;

            decimal priceWithoutTax = 0;

            while ((command = Console.ReadLine()) != "special" && command != "regular")
            {
                decimal price = decimal.Parse(command);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                priceWithoutTax += price;
            }

            if (priceWithoutTax <= 0)
            {
                Console.WriteLine("Invalid order!");

                return;
            }

            decimal taxes = priceWithoutTax * 0.2m;

            decimal priceWithTax = priceWithoutTax + taxes;


            if (command == "special")
            {
                priceWithTax = priceWithTax * 0.9m;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {priceWithoutTax:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {priceWithTax:f2}$");
        }
    }
}