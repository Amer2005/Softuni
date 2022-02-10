using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input;

            bool isListChanged = false;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split(' ');

                if (inputs[0] == "Add")
                {
                    int numberToAdd = int.Parse(inputs[1]);

                    numbers.Add(numberToAdd);

                    isListChanged = true;

                    continue;
                }

                if (inputs[0] == "Remove")
                {
                    int numberToRemove = int.Parse(inputs[1]);

                    numbers.Remove(numberToRemove);

                    isListChanged = true;

                    continue;
                }

                if (inputs[0] == "RemoveAt")
                {
                    int indexToRemove = int.Parse(inputs[1]);

                    numbers.RemoveAt(indexToRemove);

                    isListChanged = true;

                    continue;
                }

                if (inputs[0] == "Insert")
                {
                    int indexToInsert = int.Parse(inputs[2]);
                    int numberToInsert = int.Parse(inputs[1]);

                    numbers.Insert(indexToInsert, numberToInsert);

                    isListChanged = true;

                    continue;
                }

                if (inputs[0] == "Contains")
                {
                    int searchedNumber = int.Parse(inputs[1]);

                    Console.WriteLine(numbers.Contains(searchedNumber) ? "Yes" : "No such number");

                    continue;
                }

                if (inputs[0] == "PrintEven")
                {
                    Console.WriteLine(String.Join(" ", GetEvenNumbers(numbers)));

                    continue;
                }

                if (inputs[0] == "PrintOdd")
                {
                    Console.WriteLine(String.Join(" ", GetOddNumbers(numbers)));

                    continue;
                }

                if (inputs[0] == "GetSum")
                {
                    Console.WriteLine(GetSum(numbers));

                    continue;
                }

                if (inputs[0] == "Filter")
                {
                    int numberToCompare = int.Parse(inputs[2]);

                    Console.WriteLine(String.Join(" ", Filter(numbers, inputs[1], numberToCompare)));

                    continue;
                }
            }

            if (isListChanged)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        static int[] GetEvenNumbers(List<int> numbers)
        {
            return numbers.Where(x => x % 2 == 0).ToArray();
        }

        static int[] GetOddNumbers(List<int> numbers)
        {
            return numbers.Where(x => x % 2 != 0).ToArray();
        }

        static int GetSum(List<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        static int[] Filter(List<int> numbers, string compare, int number)
        {
            Func<int, bool> compareNumbersFunction;

            if (compare == ">")
            {
                compareNumbersFunction = x => x > number;
            }
            else if (compare == "<")
            {
                compareNumbersFunction = x => x < number;
            }
            else if (compare == ">=")
            {
                compareNumbersFunction = x => x >= number;
            }
            else
            {
                compareNumbersFunction = x => x <= number;
            }

            return numbers.Where(compareNumbersFunction).ToArray();
        }
    }
}
