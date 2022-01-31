using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] lenghts = new int[numbers.Length];

            int[] prev = new int[numbers.Length];

            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = -1;
                lenghts[i] = 1;
            }

            int maxLenght = 1;
            int maxStart = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[i] > numbers[j])
                    {
                        if (lenghts[j] + 1 >= lenghts[i])
                        {
                            lenghts[i] = lenghts[j] + 1;
                            prev[i] = j;
                        }
                    }
                }

                if (lenghts[i] > maxLenght)
                {
                    maxLenght = lenghts[i];
                    maxStart = i;
                }
            }

            int indexNow = maxStart;

            Stack<int> result = new Stack<int>();

            while (indexNow != -1)
            {
                result.Push(numbers[indexNow]);

                indexNow = prev[indexNow];
            }

            while (result.Count > 0)
            {
                Console.Write($"{result.Pop()} ");
            }

            Console.WriteLine();
        }
    }
}
