using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p9_KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLenght = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int maxLenght = -1;
            int maxPosition = 0;
            int maxSum = 0;
            int maxIndex = 0;
            int[] maxDnaNumbers = new int[dnaLenght];

            int index = 0;

            while (input != "Clone them!")
            {
                int[] dnaNumbers = input.Split(new char[] { '!', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentSum = 0;
                int currentLenght = 0;
                int currentMaxLenght = 0;
                int currentMaxPosition = 0;

                for (int i = 0; i < dnaNumbers.Length; i++)
                {
                    currentSum += dnaNumbers[i];

                    if (dnaNumbers[i] == 1)
                    {
                        currentLenght++;
                    }
                    else
                    {
                        if (currentLenght > currentMaxLenght)
                        {
                            currentMaxLenght = currentLenght;
                            currentMaxPosition = i;
                        }

                        currentLenght = 0;
                    }
                }

                if (currentLenght > currentMaxLenght)
                {
                    currentMaxLenght = currentLenght;
                    currentMaxPosition = dnaNumbers.Length;
                }

                currentLenght = 0;

                if (maxLenght < currentMaxLenght)
                {
                    maxLenght = currentMaxLenght;
                    maxPosition = currentMaxPosition;
                    maxSum = currentSum;
                    maxIndex = index;
                    maxDnaNumbers = dnaNumbers;
                }
                else if (maxLenght == currentMaxLenght)
                {
                    if (maxPosition > currentMaxPosition)
                    {
                        maxLenght = currentMaxLenght;
                        maxPosition = currentMaxPosition;
                        maxSum = currentSum;
                        maxIndex = index;
                        maxDnaNumbers = dnaNumbers;
                    }
                    else if (maxPosition == currentMaxPosition)
                    {
                        if (maxSum < currentSum)
                        {
                            maxLenght = currentMaxLenght;
                            maxPosition = currentMaxPosition;
                            maxSum = currentSum;
                            maxIndex = index;
                            maxDnaNumbers = dnaNumbers;
                        }
                    }
                }

                index++;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {maxIndex + 1} with sum: {maxSum}.");
            Console.WriteLine(string.Join(" ", maxDnaNumbers));
        }
    }
}
