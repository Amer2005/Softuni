using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string season = Console.ReadLine();

            double price = 0;

            string place = "";
            string typeOfTrip = "";

            if (budget <= 100)
            {
                place = "Bulgaria";
                if (season == "summer")
                {
                    price = budget * 0.3;
                    typeOfTrip = "Camp";
                }
                else
                {
                    typeOfTrip = "Hotel";
                    price = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                place = "Balkans";
                if (season == "summer")
                {
                    typeOfTrip = "Camp";
                    price = budget * 0.4;
                }
                else
                {
                    typeOfTrip = "Hotel";
                    price = budget * 0.8;
                }
            }
            else
            {
                typeOfTrip = "Hotel";
                place = "Europe";
                price = budget * 0.9;
            }

            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{typeOfTrip} - {price:f2}");
        }
    }
}
