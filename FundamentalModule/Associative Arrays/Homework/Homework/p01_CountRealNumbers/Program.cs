using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            var counts = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if(counts.ContainsKey(numbers[i]))
                {
                    counts[numbers[i]]++;
                }
                else
                {
                    counts.Add(numbers[i], 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
