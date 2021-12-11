using System;

namespace PhotoDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = int.Parse(Console.ReadLine());
            int scenes = int.Parse(Console.ReadLine());
            int timeForScene = int.Parse(Console.ReadLine());

            double totalTime = Math.Round(scenes * timeForScene + time * 0.15);

            if(totalTime >= time)
            {
                Console.WriteLine($"Time is up! To complete the movie you need {totalTime - time} minutes.");
            }
            else
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {time - totalTime} minutes left!");
            }

        }
    }
}
