using System;
using System.Collections.Generic;
using System.Linq;

namespace p07_PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(' ').ToList();

            Predicate<string> filter = name => name.Length <= nameLenght;

            names = names.FindAll(filter);

            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
