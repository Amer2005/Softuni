using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10_RadioactiveMutantVampireBunnies
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

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                int newRow = playerRow;
                int newCol = playerCol;

                if (commands[i] == 'R')
                {
                    newCol++;
                }
                else if (commands[i] == 'L')
                {
                    newCol--;
                }
                else if (commands[i] == 'U')
                {
                    newRow--;
                }
                else if (commands[i] == 'D')
                {
                    newRow++;
                }

                if (!AreCordsValid(matrix, newRow, newCol))
                {
                    matrix[playerRow, playerCol] = '.';

                    MultiplyBunnies(matrix);

                    PrintMatrix(matrix);

                    Console.WriteLine($"won: {playerRow} {playerCol}");

                    return;
                }

                matrix[playerRow, playerCol] = '.';

                playerRow = newRow;
                playerCol = newCol;

                matrix[playerRow, playerCol] = 'P';

                MultiplyBunnies(matrix);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    PrintMatrix(matrix);

                    Console.WriteLine($"dead: {playerRow} {playerCol}");

                    return;
                }
            }
        }

        static void MultiplyBunnies(char[,] matrix)
        {
            char[,] newMatrix = matrix;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        MultiplyCell(matrix, row, col);
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'b')
                    {
                        matrix[row, col] = 'B';
                    }
                }
            }
        }

        static void MultiplyCell(char[,] matrix, int  row, int col)
        {
            int r = row + 1;
            int c = col;

            if (AreCordsValid(matrix, r, c) && matrix[r, c] != 'B')
            {
                matrix[r, c] = 'b';
            }

            r = row - 1;
            c = col;

            if (AreCordsValid(matrix, r, c) && matrix[r, c] != 'B')
            {
                matrix[r, c] = 'b';
            }

            r = row;
            c = col - 1;

            if (AreCordsValid(matrix, r, c) && matrix[r, c] != 'B')
            {
                matrix[r, c] = 'b';
            }

            r = row;
            c = col + 1;

            if (AreCordsValid(matrix, r, c) && matrix[r, c] != 'B')
            {
                matrix[r, c] = 'b';
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }

        static bool AreCordsValid(char[,] matrix, int row, int col)
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
    }
}
