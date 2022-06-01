using System;
using System.Collections.Generic;
using System.Linq;

namespace p04_FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] splitedInput = Console.ReadLine().Split(' ');

            int minNum = int.Parse(splitedInput[0]);
            int maxNum = int.Parse(splitedInput[1]);

            Predicate<int> filter;

            string evenOrOdd = Console.ReadLine();

            if (evenOrOdd == "even")
            {
                filter = x => x % 2 == 0;
            }
            else
            {
                filter = x => x % 2 != 0;
            }

            List<int> numbers = new List<int>();

            for (int number = minNum; number <= maxNum; number++)
            {
                numbers.Add(number);
            }

            Console.WriteLine(String.Join(" ", numbers.FindAll(filter)));
        }
    }
}
