using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            Box<int> box = new Box<int>(list);

            int[] indexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            box.Swap(list, indexes[0], indexes[1]);

            box.Elements = list;

            Console.WriteLine(box);
        }
    }
}
