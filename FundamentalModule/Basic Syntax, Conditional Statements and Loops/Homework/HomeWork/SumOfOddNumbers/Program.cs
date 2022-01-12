using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            int number = 1;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(number);

                sum += number;

                number += 2;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
