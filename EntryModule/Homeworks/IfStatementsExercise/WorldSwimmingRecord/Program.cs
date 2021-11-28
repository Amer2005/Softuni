using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecordSeconds = double.Parse(Console.ReadLine());

            double worldRecordDistance = double.Parse(Console.ReadLine());

            double speed = double.Parse(Console.ReadLine());

            double secondsNeeded = worldRecordDistance * speed;
            secondsNeeded += Math.Floor(worldRecordDistance / 15) * 12.5;

            if (secondsNeeded < worldRecordSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {secondsNeeded:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {secondsNeeded - worldRecordSeconds:f2} seconds slower.");
            }
        }
    }
}
