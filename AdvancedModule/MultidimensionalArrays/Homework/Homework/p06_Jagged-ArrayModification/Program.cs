using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            string input;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputArgs = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new int[inputArgs.Length];

                for (int col = 0; col < inputArgs.Length; col++)
                {
                    matrix[row][col] = inputArgs[col];
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(' ');

                string action = inputArgs[0];

                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);
                int value = int.Parse(inputArgs[3]);

                if (row < 0 || row >= matrixSize)
                {
                    Console.WriteLine("Invalid coordinates");

                    continue;
                }

                if (col < 0 || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");

                    continue;
                }

                if (action == "Add")
                {
                    matrix[row][col] += value;
                }
                else
                {
                    matrix[row][col] -= value;
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
