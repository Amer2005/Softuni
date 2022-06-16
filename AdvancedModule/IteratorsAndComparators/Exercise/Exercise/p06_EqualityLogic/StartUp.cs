using System;
using System.Collections.Generic;
using System.Linq;

namespace p05_ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("A", 1);
            Person person2 = new Person("A", 1);

            //Console.WriteLine(person1.CompareTo(person2));

            SortedSet<Person> peopleSortedSet = new SortedSet<Person>();
            HashSet<Person> peopleHashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ').ToArray();

                Person personNow = new Person(inputArgs[0], int.Parse(inputArgs[1]));

                if (!peopleSortedSet.Contains(personNow))
                {
                    peopleSortedSet.Add(personNow);
                }
                
                if (!peopleHashSet.Contains(personNow))
                {
                    peopleHashSet.Add(personNow);
                }
            }

            Console.WriteLine(peopleSortedSet.Count);
            Console.WriteLine(peopleHashSet.Count);
        }
    }
}
