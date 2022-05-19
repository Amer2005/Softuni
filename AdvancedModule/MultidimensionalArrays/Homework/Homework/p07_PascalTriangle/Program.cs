using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[,] pascalTriangle = new long[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    pascalTriangle[row, col] = GetNumber(row, col, pascalTriangle);

                    Console.Write(pascalTriangle[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static long GetNumber(int row, int col, long[,] pascalTriangle)
        {
            if (col == 0 || col == row)
            {
                return 1;
            }

            return pascalTriangle[row - 1, col - 1] + pascalTriangle[row - 1, col];
        }
    }
}
