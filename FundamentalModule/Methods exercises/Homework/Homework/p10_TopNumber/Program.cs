using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10_TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join("\n", GetTopNumberInRange(1, n)));
        }

        static int[] GetTopNumberInRange(int start, int end)
        {
            List<int> topNumbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsNumberTopNumber(i))
                {
                    topNumbers.Add(i);
                }
            }

            return topNumbers.ToArray();
        }

        static bool IsNumberTopNumber(int number)
        {
            bool oddNumberFound = false;

            int sumOfDigits = 0;

            while (number != 0)
            {
                int digit = number % 10;

                sumOfDigits += digit;

                if (digit % 2 != 0)
                {
                    oddNumberFound = true;
                }

                number /= 10;
            }

            if (oddNumberFound && sumOfDigits % 8 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
