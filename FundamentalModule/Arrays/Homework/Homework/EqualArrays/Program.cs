using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] FirstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] SecondArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i < Math.Min(FirstArray.Length, SecondArray.Length); i++)
            {
                sum += FirstArray[i];

                if (FirstArray[i] != SecondArray[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");

                    return;
                }
            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
