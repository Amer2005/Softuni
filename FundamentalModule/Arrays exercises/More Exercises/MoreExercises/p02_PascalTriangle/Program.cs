using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] triangle = new int[n,n];

            Console.WriteLine(1);

            for (int i = 1; i < n; i++)
            {
                triangle[i, 0] = 1;
                triangle[i, i] = 1;

                Console.Write("1 ");

                for (int j = 1; j < i; j++)
                {
                    triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];

                    Console.Write($"{triangle[i, j]} ");
                }

                Console.WriteLine("1");
            }

        }
    }
}
