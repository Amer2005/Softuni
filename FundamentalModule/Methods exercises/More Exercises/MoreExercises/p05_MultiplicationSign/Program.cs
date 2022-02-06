using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int symbol = GetSymbol(numbers);

            if (symbol == 0)
            {
                Console.WriteLine("zero");
            }
            else if (symbol == -1)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }

        static int GetSymbol(int[] numbers)
        {
            int numberOfNegativeNumbers = 0;
            bool zeroFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numberOfNegativeNumbers++;
                }

                if (numbers[i] == 0)
                {
                    zeroFound = true;
                    break;
                }
            }

            if (zeroFound)
            {
                return 0;
            }

            if (numberOfNegativeNumbers % 2 != 0)
            {
                return -1;
            }

            return 1;
        }
    }
}
