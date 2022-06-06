using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] splittedArgs = Console.ReadLine().Split(' ');

                people.Add(new Person(splittedArgs[0], int.Parse(splittedArgs[1])));
            }

            Console.WriteLine(String.Join(Environment.NewLine,
                people.Where(p => p.Age > 30)
                        .OrderBy(p => p.Name)
                        .Select(p => $"{p.Name} - {p.Age}")));
        }
    }
}
