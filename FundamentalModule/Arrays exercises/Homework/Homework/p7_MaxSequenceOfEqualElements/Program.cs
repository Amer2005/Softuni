using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int currentLenght = 1;
            int currentStart = 0;

            int maxLenght = 1;
            int maxStart = 0;
            int maxEnd = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    currentLenght++;
                }
                else
                {
                    if (currentLenght > maxLenght)
                    {
                        maxStart = currentStart;
                        maxEnd = i - 1;
                        maxLenght = currentLenght;
                    }

                    currentStart = i;
                    currentLenght = 1;
                }
            }

            if (currentLenght > maxLenght)
            {
                maxStart = currentStart;
                maxEnd = array.Length - 1;
            }

            for (int i = maxStart; i <= maxEnd; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
