using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringArrays = Console.ReadLine()
                .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<double> resultArray = new List<double>();

            for (int i = stringArrays.Length - 1; i >= 0; i--)
            {
                List<double> tempList = stringArrays[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                resultArray.AddRange(tempList);
            }

            Console.WriteLine(String.Join(" ", resultArray));
        }
    }
}
