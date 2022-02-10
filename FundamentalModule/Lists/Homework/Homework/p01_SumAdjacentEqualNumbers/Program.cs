using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            bool areEqualNumbersFound = true;

            while (areEqualNumbersFound)
            {
                areEqualNumbersFound = false;
                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        areEqualNumbersFound = true;

                        numbers[i] *= 2;

                        numbers.RemoveAt(i - 1);
                        break;
                    }
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
