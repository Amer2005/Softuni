using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            bool found = false;

            int iter = 0;

            int a = 0;
            int b = 0;

            for (a = min; a <= max; a++)
            {
                for (b = min; b <= max; b++)
                {
                    iter++;
                    if (a + b == sum)
                    {
                        found = true;
                        break;
                    }
                }

                if(found)
                {
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine($"Combination N:{iter} ({a} + {b} = {sum})");
            }
            else
            {
                Console.WriteLine($"{iter} combinations - neither equals {sum}");
            }
        }
    }
}
