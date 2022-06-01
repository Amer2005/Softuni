using System;
using System.Collections.Generic;
using System.Linq;

namespace p06_ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int divider = int.Parse(Console.ReadLine());

            Action<List<int>> reverse = list => list.Reverse();

            Predicate<int> filter = x => x % divider != 0;

            numbers = numbers.FindAll(filter);

            reverse(numbers);

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
