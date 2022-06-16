using System;
using System.Collections.Generic;
using System.Linq;

namespace p05_ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split(' ');

                people.Add(new Person(parts[0], int.Parse(parts[1]), parts[2]));
            }

            int searchIndex = int.Parse(Console.ReadLine());

            searchIndex--;

            int matchesCount = people.Count(x => x.CompareTo(people[searchIndex]) == 0);

            if (matchesCount == 1)
            {
                Console.WriteLine("No matches");

                return;
            }

            Console.WriteLine($"{matchesCount} {people.Count - matchesCount} {people.Count}");
        }
    }
}
