using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] actionArgs = input.Split(' ');

                if (actionArgs[0] == "Add")
                {
                    int number = int.Parse(actionArgs[1]);

                    numbers.Add(number);
                }
                else if (actionArgs[0] == "Insert")
                {
                    int number = int.Parse(actionArgs[1]);
                    int index = int.Parse(actionArgs[2]);

                    if (!IsIndexInList(numbers, index))
                    {
                        Console.WriteLine("Invalid index");

                        continue;
                    }

                    numbers.Insert(index, number);
                }
                else if (actionArgs[0] == "Remove")
                {
                    int index = int.Parse(actionArgs[1]);

                    if (!IsIndexInList(numbers, index))
                    {
                        Console.WriteLine("Invalid index");

                        continue;
                    }

                    numbers.RemoveAt(index);
                }
                else if(actionArgs[0] == "Shift")
                {
                    int shiftAmount = int.Parse(actionArgs[2]);
                    string direction = actionArgs[1];

                    if (direction == "right")
                    {
                        shiftAmount = -shiftAmount;
                    }

                    numbers = ShiftList(numbers, shiftAmount);
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        static List<int> ShiftList(List<int> numbers, int shiftAmout)
        {
            if(shiftAmout == 0)
            {
                return numbers;
            }

            List<int> result = new List<int>();

            shiftAmout %= numbers.Count;

            int indexNow = shiftAmout;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (indexNow < 0)
                {
                    indexNow = numbers.Count + indexNow;
                }

                if (indexNow >= numbers.Count)
                {
                    indexNow %= numbers.Count;
                }

                result.Add(numbers[indexNow]);

                indexNow += 1;
            }

            return result;
        }

        static bool IsIndexInList(List<int> numbers, int index)
        {
            if (index < 0)
            {
                return false;
            }

            if (index >= numbers.Count)
            {
                return false;
            }

            return true;
        }
    }
}
