using System;
using System.Linq;

namespace p03_CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int> GetMinNumber = x => x.Min();

            Console.WriteLine(GetMinNumber(numbers));
        }
    }
}
