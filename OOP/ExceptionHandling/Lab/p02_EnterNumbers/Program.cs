using System;
using System.Collections.Generic;

namespace p02_EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int minNumber = 1;
            const int maxNumber = 100;

            List<int> numbers = new List<int>();

            while(numbers.Count < 10)
            {
                try
                {
                    int number = ReadNumber(minNumber, maxNumber);

                    numbers.Add(number);
                    minNumber = number;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static int ReadNumber(int minNumber, int maxNumber)
        {
            int number = int.Parse(Console.ReadLine());

            if (number <= minNumber || number >= maxNumber)
            {
                throw new ArgumentException($"Your number is not in range {minNumber} - {maxNumber}!");
            }

            return number;
        }
    }
}
