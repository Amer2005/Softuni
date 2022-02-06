using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{(decimal)GetFactorial(firstNumber) / (decimal)GetFactorial(secondNumber):f2}");
        }

        static long GetFactorial(long n)
        {
            long factorial = 1;

            for (long i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
