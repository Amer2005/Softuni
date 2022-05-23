using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] matrix = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                long[] ParsedInput = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(long.Parse)
               .ToArray();

                matrix[row] = ParsedInput;
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = Console.ReadLine().Split(' ');

                string action = inputArgs[0];

                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);
                long value = long.Parse(inputArgs[3]);

                if (!AreCordsValid(matrix, row, col))
                {
                    continue;
                }

                if (action == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(long[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(String.Join(" ", matrix[row]));
            }
        }

        static bool AreCordsValid(long[][] matrix, int row, int col)
        {
            if(row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}