using System;
using System.Linq;

namespace p07_CustomComparator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Array.Sort(array, new EvenOddComparator());

            Console.WriteLine(String.Join(" ", array));
        }
    }
}
