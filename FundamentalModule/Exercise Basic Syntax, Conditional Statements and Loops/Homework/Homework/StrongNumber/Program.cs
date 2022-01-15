using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongNumber
{
    internal class Program
    {
        private static int Factorial(int n)
        {
            int mult = 1;

            for (int i = 1; i <= n; i++)
            {
                mult *= i;
            }

            return mult;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            int newN = n;

            while (n != 0)
            {
                int digit = n % 10;
                n /= 10;

                sum += Factorial(digit);
            }

            if (sum == newN)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
