using System;
using System.Collections.Generic;
using System.Linq;

namespace p08_ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> numbers = new List<int>();

            Predicate<int> filter = num => !dividers.Exists(x => num % x != 0);

            for (int i = 1; i <= maxNum; i++)
            {
                numbers.Add(i);
            }

            numbers = numbers.FindAll(filter);

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
