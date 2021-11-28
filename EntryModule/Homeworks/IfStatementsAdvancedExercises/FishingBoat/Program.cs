using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfPeople = int.Parse(Console.ReadLine());

            double totalPrice = 0;

            if(season == "Spring")
            {
                totalPrice = 3000;
            }
            else if(season == "Summer" || season == "Autumn")
            {
                totalPrice = 4200;
            }
            else
            {
                totalPrice = 2600;
            }

            if(numberOfPeople <= 6)
            {
                totalPrice -= totalPrice * 0.1;
            }
            else if (numberOfPeople <= 11)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else
            {
                totalPrice -= totalPrice * 0.25;
            }

            if(numberOfPeople % 2 == 0 && season != "Autumn")
            {
                totalPrice -= totalPrice * 0.05;
            }

            if(totalPrice <= budget)
            {
                Console.WriteLine($"Yes! You have {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva.");
            }
        }
    }
}
