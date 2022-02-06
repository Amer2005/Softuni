using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p11_ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string action;

            while ((action = Console.ReadLine()) != "end")
            {
                string[] actionArgs = action.Split(' ');

                if (actionArgs[0] == "exchange")
                {
                    int index = int.Parse(actionArgs[1]);

                    int[] newArray = ExchangeArray(array, index);

                    if (newArray == null)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        array = newArray;
                    }
                }

                if (actionArgs[0] == "max")
                {
                    int maxIndex = GetIndexOfMaxEvenOrOdd(array, actionArgs[1]);

                    if(maxIndex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(maxIndex);
                    }
                }

                if (actionArgs[0] == "min")
                {
                    int maxIndex = GetIndexOfMinEvenOrOdd(array, actionArgs[1]);

                    if (maxIndex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(maxIndex);
                    }
                }

                if (actionArgs[0] == "first")
                {
                    int count = int.Parse(actionArgs[1]);

                    int[] subArray = FirstCountOfEvenOrOdd(array, count, actionArgs[2]);

                    if (subArray == null)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        PrintArray(subArray);
                    }
                }

                if (actionArgs[0] == "last")
                {
                    int count = int.Parse(actionArgs[1]);

                    int[] subArray = LastCountOfEvenOrOdd(array, count, actionArgs[2]);

                    if (subArray == null)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        PrintArray(subArray);
                    }
                }
            }

            PrintArray(array);
        }

        static int[] ExchangeArray(int[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                return null;
            }

            int[] newArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[(i + index + 1) % array.Length];
            }

            return newArray;
        }

        static int GetIndexOfMaxEvenOrOdd(int[] array, string evenOrOdd)
        {
            int max = int.MinValue;
            int maxIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (evenOrOdd == "even")
                {
                    if (array[i] % 2 == 0 && array[i] >= max)
                    {
                        max = array[i];
                        maxIndex = i;
                    }
                }
                if (evenOrOdd == "odd")
                {
                    if (array[i] % 2 != 0 && array[i] >= max)
                    {
                        max = array[i];
                        maxIndex = i;
                    }
                }
            }

            return maxIndex;
        }


        static int GetIndexOfMinEvenOrOdd(int[] array, string evenOrOdd)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (evenOrOdd == "even")
                {
                    if (array[i] % 2 == 0 && array[i] <= min)
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }
                if (evenOrOdd == "odd")
                {
                    if (array[i] % 2 != 0 && array[i] <= min)
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }
            }

            return minIndex;
        }

        static int[] FirstCountOfEvenOrOdd(int[] array, int count, string evenOrOdd)
        {
            if (count < 0 || count > array.Length)
            {
                return null;
            }

            List<int> numbers = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                bool isNumberValid = false;

                if (evenOrOdd == "even")
                {
                    if (array[i] % 2 == 0)
                    {
                        isNumberValid = true;
                    }
                }
                else
                {
                    if (array[i] % 2 != 0)
                    {
                        isNumberValid = true;
                    }
                }


                if (isNumberValid)
                {
                    numbers.Add(array[i]);
                }

                if (numbers.Count == count)
                {
                    break;
                }
            }

            return numbers.ToArray();
        }

        static int[] LastCountOfEvenOrOdd(int[] array, int count, string evenOrOdd)
        {
            if (count < 0 || count > array.Length)
            {
                return null;
            }

            List<int> numbers = new List<int>();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                bool isNumberValid = false;

                if (evenOrOdd == "even")
                {
                    if (array[i] % 2 == 0)
                    {
                        isNumberValid = true;
                    }
                }
                else
                {
                    if (array[i] % 2 != 0)
                    {
                        isNumberValid = true;
                    }
                }


                if (isNumberValid)
                {
                    numbers.Add(array[i]);
                }

                if (numbers.Count == count)
                {
                    break;
                }
            }

            numbers.Reverse();

            return numbers.ToArray();
        }
    
        static void PrintArray(int[] array)
        {
            Console.WriteLine($"[{String.Join(", ", array)}]");
        }
    }
}

/*
17 16 15 14 13 12 11
max even
min odd
first 3 even
exchange 2
first 3 odd
exchange 2
first 3 odd
last 3 odd
max odd
end
*/