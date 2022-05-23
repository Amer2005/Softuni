using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_MatrixShuffling
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

            string input;

            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(' ').ToArray();

                if (inputArgs.Length != 5)
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                string action = inputArgs[0];

                if (action != "swap")
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                int row1 = int.Parse(inputArgs[1]);
                int col1 = int.Parse(inputArgs[2]);
                int row2 = int.Parse(inputArgs[3]);
                int col2 = int.Parse(inputArgs[4]);

                if(!AreCordsValid(matrix, row1, col1) || !AreCordsValid(matrix, row2, col2))
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                int temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;

                PrintMatrix(matrix);
            }
        }

        static bool AreCordsValid(int[,] matrix, int row, int col)
        {
            if(row < 0)
            {
                return false;
            }

            if(col < 0)
            {
                return false;
            }

            if(row >= matrix.GetLength(0))
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
