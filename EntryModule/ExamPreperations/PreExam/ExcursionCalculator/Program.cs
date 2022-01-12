using System;

namespace ExcursionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double tripPrice = 0;

            if(season == "spring")
            {
                if(people <= 5)
                {
                    tripPrice = people * 50;
                }
                else
                {
                    tripPrice = people * 48;
                }
            }
            else if (season == "summer")
            {
                if (people <= 5)
                {
                    tripPrice = people * 48.5;
                }
                else
                {
                    tripPrice = people * 45;
                }

                tripPrice = tripPrice * (1 - 0.15);
            }
            else if (season == "autumn")
            {
                if (people <= 5)
                {
                    tripPrice = people * 60;
                }
                else
                {
                    tripPrice = people * 49.5;
                }
            }
            else if (season == "winter")
            {
                if (people <= 5)
                {
                    tripPrice = people * 86;
                }
                else
                {
                    tripPrice = people * 85;
                }

                tripPrice = tripPrice * 1.08;
            }

            Console.WriteLine($"{tripPrice:f2} leva.");
        }
    }
}
