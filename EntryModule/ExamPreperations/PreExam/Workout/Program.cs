using System;

namespace Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double distanceRanToday = double.Parse(Console.ReadLine());

            double totalDistanceRan = distanceRanToday;

            for (int i = 0; i < days; i++)
            {
                double increase = double.Parse(Console.ReadLine());

                distanceRanToday = distanceRanToday * (100 + increase) / 100;

                totalDistanceRan += distanceRanToday;
            }

            if(totalDistanceRan < 1000)
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - totalDistanceRan)} more kilometers");
            }
            else
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalDistanceRan - 1000)} more kilometers!");
            }
        }
    }
}
