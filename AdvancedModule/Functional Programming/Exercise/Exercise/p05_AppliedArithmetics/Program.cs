using System;
using System.Collections.Generic;
using System.Linq;

namespace p05_AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Func<List<int>, List<int>> add = list => list.Select(n => n + 1).ToList();
            Func<List<int>, List<int>> multiply = list => list.Select(n => n * 2).ToList();
            Func<List<int>, List<int>> subtract = list => list.Select(n => n - 1).ToList();
            Action<List<int>> print = list => Console.WriteLine(String.Join(" ", list));

            string action;

            while((action = Console.ReadLine()) != "end")
            {
                if (action == "add")
                {
                    numbers = add(numbers);
                }
                else if (action == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (action == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (action == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
