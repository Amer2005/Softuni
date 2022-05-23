using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputParsed = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputParsed[0];
            int cols = inputParsed[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputArgs[col];
                }
            }

            int total2By2s = 0;

            int maxSum = int.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    if (GetSumOf3By3(matrix, row, col) > maxSum)
                    {
                        maxSum = GetSumOf3By3(matrix, row, col);
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int rowNow = maxSumRow; rowNow < maxSumRow + 3; rowNow++)
            {
                for (int colNow = maxSumCol; colNow < maxSumCol + 3; colNow++)
                {
                    Console.Write($"{matrix[rowNow, colNow]} ");
                }
                Console.WriteLine();
            }
        }

        static int GetSumOf3By3(int[,] matrix, int row, int col)
        {
            int sum = 0;

            for (int rowNow = row; rowNow < row + 3; rowNow++)
            {
                for (int colNow = col; colNow < col + 3; colNow++)
                {
                    sum += matrix[rowNow, colNow];
                }
            }

            return sum;
        }
    }
}
