using System;
using System.Collections.Generic;
using System.Linq;

namespace p11_TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameSum = int.Parse(Console.ReadLine());

            List<string> people = Console.ReadLine().Split(' ').ToList();

            Console.WriteLine(people
                .First(name => name
                .Select(ch => (int) ch)
                .Sum() >= nameSum));
        }
    }
}
