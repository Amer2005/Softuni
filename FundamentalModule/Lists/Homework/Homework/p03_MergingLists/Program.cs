using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int longerCount = Math.Max(firstList.Count, secondList.Count);

            List<int> result = new List<int>();

            for (int i = 0; i < longerCount; i++)
            {
                if(i < firstList.Count)
                {
                    result.Add(firstList[i]);
                }

                if (i < secondList.Count)
                {
                    result.Add(secondList[i]);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
