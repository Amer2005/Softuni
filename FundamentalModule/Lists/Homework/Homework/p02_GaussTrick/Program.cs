using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> gaussNumbers = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                gaussNumbers.Add(numbers[i] + numbers[numbers.Count - i - 1]);
            }

            if (numbers.Count % 2 != 0)
            {
                gaussNumbers.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(String.Join(" ", gaussNumbers));
        }
    }
}
