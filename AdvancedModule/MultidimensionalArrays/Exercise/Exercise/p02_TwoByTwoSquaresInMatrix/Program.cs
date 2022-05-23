using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_TwoByTwoSquaresInMatrix
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

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputArgs[col];
                }
            }

            int total2By2s = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (IsItTheSame2by2(matrix, row, col))
                    {
                        total2By2s++;
                    }
                }
            }

            Console.WriteLine(total2By2s);
        }

        static bool IsItTheSame2by2(char[,] matrix, int row, int col)
        {

            for (int rowNow = row; rowNow < row + 2; rowNow++)
            {
                for (int colNow = col; colNow < col + 2; colNow++)
                {
                    if (matrix[row, col] != matrix[rowNow, colNow])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
