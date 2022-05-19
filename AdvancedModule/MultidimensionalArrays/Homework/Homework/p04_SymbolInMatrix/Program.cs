using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            int symbolRow = -1;
            int symbolCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        symbolRow = row;
                        symbolCol = col;

                        break;
                    }
                }

                if (symbolRow != -1)
                {
                    break;
                }
            }

            if (symbolRow == -1)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
            else
            {
                Console.WriteLine($"({symbolRow}, {symbolCol})");
            }
        }
    }
}
