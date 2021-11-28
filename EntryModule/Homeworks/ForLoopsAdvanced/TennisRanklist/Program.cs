using System;

namespace TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double startingPoints = double.Parse(Console.ReadLine());

            double points = 0;

            int wins = 0;
            int finals = 0;
            int semiFinals = 0;

            for (int i = 0; i < n; i++)
            {
                string place = Console.ReadLine();

                if (place == "W")
                {
                    wins++;
                }
                else if (place == "SF")
                {
                    semiFinals++;
                }
                else
                {
                    finals++;
                }
            }

            points = wins * 2000 + finals * 1200 + semiFinals * 720;

            Console.WriteLine($"Final points: {points + startingPoints}");
            Console.WriteLine($"Average points: {Math.Floor(points / n)}");
            Console.WriteLine($"{(double)wins / n * 100:f2}%");
        }
    }
}
