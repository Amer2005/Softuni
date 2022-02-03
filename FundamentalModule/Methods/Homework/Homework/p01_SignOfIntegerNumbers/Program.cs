using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintIsPositive(number);
        }

        static void PrintIsPositive(int number)
        {
            if(number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");

                return;
            }

            if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");

                return;
            }

            Console.WriteLine($"The number {number} is zero.");
        }
    }
}
