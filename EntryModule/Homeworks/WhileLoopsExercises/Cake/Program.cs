using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int cakeSize = n * m;

            int eatenCake = 0;

            while(cakeSize > eatenCake)
            {
                string input = Console.ReadLine();

                if(input == "STOP")
                {
                    break;
                }

                int eaten = int.Parse(input);

                eatenCake += eaten;
            }

            if(eatenCake > cakeSize)
            {
                Console.WriteLine($"No more cake left! You need {eatenCake - cakeSize} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cakeSize - eatenCake} pieces are left.");
            }
        }
    }
}
