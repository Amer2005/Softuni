using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_Bombs
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

            string[] bombLocations = Console.ReadLine().Split(' ');

            for (int i = 0; i < bombLocations.Length; i++)
            {
                string[] bombArgs = bombLocations[i].Split(',');

                int row = int.Parse(bombArgs[0]);

                int col = int.Parse(bombArgs[1]);

                if (matrix[row, col] <= 0)
                {
                    continue;
                }

                Explode(matrix, row, col);
            }

            int numberOfAliveCells = 0;
            int sumOfAliveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] <= 0)
                    {
                        continue;
                    }

                    numberOfAliveCells++;

                    sumOfAliveCells += matrix[row, col];
                }
            }

            Console.WriteLine($"Alive cells: {numberOfAliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            PrintMatrix(matrix);
        }

        static void Explode(int [,] matrix, int bombRow, int bombCol)
        {
            int bombSize = matrix[bombRow, bombCol];

            matrix[bombRow, bombCol] = 0;

            for (int row = bombRow - 1; row <= bombRow + 1; row++)
            {
                for (int col = bombCol - 1; col <= bombCol + 1; col++)
                {
                    if (AreCordsValid(matrix, row, col))
                    {
                        if (matrix[row, col] <= 0)
                        {
                            continue;
                        }

                        matrix[row, col] -= bombSize;
                    }
                }
            }
        }

        static bool AreCordsValid(int[,] matrix, int row, int col)
        {
            if (row < 0)
            {
                return false;
            }

            if (col < 0)
            {
                return false;
            }

            if (row >= matrix.GetLength(0))
            {
                return false;
            }

            if (col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
