using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p6_EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;

            bool equalSumsFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                rightSum += array[i];
            }

            rightSum -= array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    equalSumsFound = true;
                    break;
                }
                leftSum += array[i];

                if (i < array.Length - 1)
                {
                    rightSum -= array[i + 1];
                }
            }

            if (!equalSumsFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
