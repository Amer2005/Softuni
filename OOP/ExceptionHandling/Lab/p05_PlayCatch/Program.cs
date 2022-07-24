using System;
using System.Collections.Generic;
using System.Linq;

namespace p05_PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int exceptionsCout = 0;

            while (exceptionsCout < 3)
            {
                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = inputArgs[0];
                try
                {
                    if (action == "Replace")
                    {
                        int index = int.Parse(inputArgs[1]);
                        int element = int.Parse(inputArgs[2]);

                        Replace(index, element, numbers);
                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(inputArgs[1]);
                        int endIndex = int.Parse(inputArgs[2]);

                        Print(startIndex, endIndex, numbers);
                    }
                    else
                    {
                        int index = int.Parse(inputArgs[1]);

                        Show(index, numbers);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCout++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCout++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static void Replace(int index, int element, List<int> numbers)
        {
            numbers[index] = element;
        }

        static void Print(int startIndex, int endIndex, List<int> numbers)
        {
            if (!IsIndexValid(startIndex, numbers) || !IsIndexValid(endIndex, numbers))
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            if (startIndex > endIndex)
            {
                throw new ArgumentException("Start index bigger than end index");
            }

            Console.WriteLine(String.Join(", ", numbers.Skip(startIndex).SkipLast(numbers.Count - endIndex - 1)));
        }

        static void Show(int index, List<int> numbers)
        {
            Console.WriteLine(numbers[index]);
        }

        static bool IsIndexValid(int index, List<int> numbers)
        {
            if (index < 0 || index >= numbers.Count)
            {
                return false;
            }

            return true;
        }
    }
}
