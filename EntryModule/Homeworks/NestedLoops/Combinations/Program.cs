using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int br = 0;

            for (int x1 = n; x1 >= 0; x1--)
            {
                for (int x2 = n - x1; x2 >= 0; x2--)
                {
                    br++;
                }
            }

            Console.WriteLine(br);
        }
    }
}
