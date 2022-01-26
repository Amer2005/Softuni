using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while (numbers.Length > 1)
            {
                CondenseTheArray(ref numbers);
            }

            Console.WriteLine(numbers[0]);

        }

        private static void CondenseTheArray(ref int[] numbers)
        {
            int[] condensedNumbers = new int[numbers.Length - 1];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                condensedNumbers[i] = numbers[i] + numbers[i + 1];
            }

            numbers = condensedNumbers;
        }
    }
}
