using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(" ", GetTribonachiNumbers(n)));
        }

        static int[] GetTribonachiNumbers(int n)
        {
            if (n == 2)
            {
                return new int[] { 1, 1};
            }

            if (n == 1)
            {
                return new int[] { 1 };
            }

            List<int> tribonachiNumbers = new List<int> { 1, 1, 2};

            for (int i = 3; i < n; i++)
            {
                tribonachiNumbers.Add(tribonachiNumbers[i - 1] + tribonachiNumbers[i - 2] + tribonachiNumbers[i - 3]);
            }

            return tribonachiNumbers.ToArray();
        }
    }
}
