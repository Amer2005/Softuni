using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();

            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double discount = 0;

            double price = 0;

            if(flowers == "Roses")
            {
                if(numberOfFlowers > 80)
                {
                    discount = 10;
                }

                price = 5;
            }
            else if (flowers == "Dahlias")
            {
                if (numberOfFlowers > 90)
                {
                    discount = 15;
                }

                price = 3.8;
            }
            else if (flowers == "Tulips")
            {
                if (numberOfFlowers > 80)
                {
                    discount = 15;
                }

                price = 2.8;
            }
            else if (flowers == "Narcissus")
            {
                if (numberOfFlowers < 120)
                {
                    discount = -15;
                }

                price = 3;
            }
            else if (flowers == "Gladiolus")
            {
                if (numberOfFlowers < 80)
                {
                    discount = -20;
                }

                price = 2.5;
            }

            double totalPrice = price * numberOfFlowers * (100 - discount) / 100;

            if(budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {flowers} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
        }
    }
}
