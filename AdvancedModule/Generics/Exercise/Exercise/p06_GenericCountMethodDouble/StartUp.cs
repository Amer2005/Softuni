using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(CompareToOthers(list, element));
        }

        static int CompareToOthers<T>(List<T> elements, T element) where T : IComparable
        {
            return elements.Count(x => x.CompareTo(element) == 1);
        }
    }
}
