using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputArgs[col];
                }
            }

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                firstDiagonalSum += matrix[row, row];
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondDiagonalSum += matrix[row, matrix.GetLength(1) - row - 1];
            }

            Console.WriteLine(Math.Abs(secondDiagonalSum - firstDiagonalSum));
        }
    }
}
