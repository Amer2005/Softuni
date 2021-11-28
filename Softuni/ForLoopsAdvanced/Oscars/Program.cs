using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actor = Console.ReadLine();

            double score = double.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            double neededScore = 1250.5;

            for (int i = 0; i < n; i++)
            {
                string judge = Console.ReadLine();

                double judgeScore = double.Parse(Console.ReadLine());

                score += (judge.Length * judgeScore) / 2;

                if(score >= neededScore)
                {
                    break;
                }
            }

            if (score < neededScore)
            {
                Console.WriteLine($"Sorry, {actor} you need {neededScore - score:f1} more!");
            }
            else
            {
                Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {score:f1}!");
            }
        }
    }
}
