using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;

            do
            {
                string input = Console.ReadLine();

                bool end = false;

                if (input == "Going home")
                {
                    end = true;

                    input = Console.ReadLine();
                }

                int stepsNow = int.Parse(input);

                steps += stepsNow;

                if (end)
                {
                    break;
                }
            }
            while (steps < 10000);

            if(steps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }
        }
    }
}
