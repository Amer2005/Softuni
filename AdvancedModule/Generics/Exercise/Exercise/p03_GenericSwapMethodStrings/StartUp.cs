using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> strings = new List<string>();

            for (int i = 0; i < n; i++)
            {
                strings.Add(Console.ReadLine());
            }

            Box<string> box = new Box<string>(strings);

            int[] indexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            box.Swap(strings, indexes[0], indexes[1]);

            box.Elements = strings;

            Console.WriteLine(box);
        }
    }
}
