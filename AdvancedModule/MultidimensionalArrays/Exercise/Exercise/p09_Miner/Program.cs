using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            string[] commands = Console.ReadLine().Split(' ');

            int minerRow = 0;
            int minerCol = 0;

            int AmountOfCoal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputArgs = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputArgs[col];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        AmountOfCoal++;
                    }
                }
            }

            int coalCollected = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                int newRow = minerRow;
                int newCol = minerCol;

                if (commands[i] == "right")
                {
                    newCol++;
                }
                else if (commands[i] == "left")
                {
                    newCol--;
                }
                else if (commands[i] == "up")
                {
                    newRow--;
                }
                else if (commands[i] == "down")
                {
                    newRow++;
                }

                if (!AreCordsValid(matrix, newRow, newCol))
                {
                    continue;
                }

                if (matrix[newRow, newCol] == 'c')
                {
                    coalCollected++;
                }
                else if(matrix[newRow, newCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({newRow}, {newCol})");

                    return;
                }

                matrix[minerRow, minerCol] = '*';
                minerRow = newRow;
                minerCol = newCol;

                matrix[minerRow, minerCol] = 's';
            }

            if (coalCollected == AmountOfCoal)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{AmountOfCoal - coalCollected} coals left. ({minerRow}, {minerCol})");
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

        static void PrintMatrix(char[,] matrix)
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
