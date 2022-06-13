using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            string element = Console.ReadLine();

            Console.WriteLine(CompareToOthers(list, element));
        }

        static int CompareToOthers<T>(List<T> elements, T element) where T : IComparable
        {
            return elements.Count(x => x.CompareTo(element) == 1);
        }
    }
}
