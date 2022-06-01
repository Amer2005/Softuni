using System;
using System.Collections.Generic;
using System.Linq;

namespace p02_KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> array = Console.ReadLine().Split(' ').ToList();

            Action<string> print = x => Console.WriteLine($"Sir {x}");

            array.ForEach(print);
        }
    }
}
