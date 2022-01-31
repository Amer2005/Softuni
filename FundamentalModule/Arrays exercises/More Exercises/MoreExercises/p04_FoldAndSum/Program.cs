using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = array.Length / 4;

            int[] firstFold = new int[array.Length / 2];
            int[] secondFold = new int[array.Length / 2];

            for (int i = k; i < 3 * k; i++)
            {
                firstFold[i - k] = array[i];
            }

            for (int i = 0; i < k; i++)
            {
                secondFold[i] = array[k - i - 1];
            }

            for (int i = k * 4 - 1; i >= 3 * k; i--)
            {
                int foldIndex = k + k * 4 - 1 - i;

                secondFold[foldIndex] = array[i];
            }

            for (int i = 0; i < k * 2; i++)
            {
                Console.Write($"{firstFold[i] + secondFold[i]} ");
            }
            Console.WriteLine();
            //Console.WriteLine(string.Join(" ", firstFold));
            //Console.WriteLine(string.Join(" ", secondFold));
        }
    }
}
