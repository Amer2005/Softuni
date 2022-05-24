using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> timesSeen = new Dictionary<double, int>();

            foreach (var number in array)
            {
                if (!timesSeen.ContainsKey(number))
                {
                    timesSeen.Add(number, 1);
                }
                else
                {
                    timesSeen[number]++;
                }
            }

            foreach (var keyValuePair in timesSeen)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value} times");
            }
        }
    }
}
