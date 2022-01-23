using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split();

                BigInteger firstNumber = BigInteger.Parse(inputs[0]);
                BigInteger secondNumber = BigInteger.Parse(inputs[1]);

                if (firstNumber < secondNumber)
                {
                    firstNumber = secondNumber;
                }

                Console.WriteLine(SumOfDigits(firstNumber));
            }
        }

        private static BigInteger SumOfDigits(BigInteger n)
        {
            n = BigInteger.Abs(n);

            BigInteger sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }
    }
}
