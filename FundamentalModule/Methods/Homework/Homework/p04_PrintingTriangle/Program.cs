using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTriangle(n);
        }

        static void PrintTriangle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"{j + 1} ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n - i - 2; j >= 0; j--)
                {
                    Console.Write($"{n - i - 1 - j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
