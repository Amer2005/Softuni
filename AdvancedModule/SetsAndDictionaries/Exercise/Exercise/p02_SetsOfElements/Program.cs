using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputParsed = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int countOfFirstNumbers = inputParsed[0];
            int countOfSecondNumbers = inputParsed[1];

            HashSet<int> numbersInSecond = new HashSet<int>();

            int[] firstSet = new int[countOfFirstNumbers];

            for (int i = 0; i < countOfFirstNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSet[i] = number;
            }

            int[] secondSet = new int[countOfFirstNumbers];

            for (int i = 0; i < countOfSecondNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet[i] = number;
            }

            List<int> result = new List<int>();

            for (int i = 0; i < countOfSecondNumbers; i++)
            {
                int number = secondSet[i];

                if (!numbersInSecond.Contains(number))
                {
                    numbersInSecond.Add(number);
                }
            }

            for (int i = 0; i < countOfFirstNumbers; i++)
            {
                int number = firstSet[i];

                if (numbersInSecond.Contains(number))
                {
                    result.Add(number);

                    numbersInSecond.Remove(number);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
