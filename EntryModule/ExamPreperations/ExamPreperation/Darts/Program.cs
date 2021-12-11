using System;

namespace Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            string multiplication = Console.ReadLine();

            int score = 301;

            int numOfShots = 0;

            int numOfMisses = 0;

            while(multiplication != "Retire")
            {
                int shot = int.Parse(Console.ReadLine());

                if (multiplication == "Double")
                {
                    shot *= 2;
                }
                else if(multiplication == "Triple")
                {
                    shot *= 3;
                }

                if (shot > score)
                {
                    numOfMisses++;
                }
                else
                {
                    numOfShots++;
                    score -= shot;
                }

                if(score <= 0)
                {
                    Console.WriteLine($"{name} won the leg with {numOfShots} shots.");

                    return;
                }

                multiplication = Console.ReadLine();
            }

            Console.WriteLine($"{name} retired after {numOfMisses} unsuccessful shots.");
        }
    }
}
