using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Person[] people = new Person[numberOfPeople];

            for (int i = 0; i < numberOfPeople; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person(inputArgs[0], int.Parse(inputArgs[1]));
            }

            string compareType = Console.ReadLine();

            int compareAge = int.Parse(Console.ReadLine());

            Func<Person, bool> filter;

            if (compareType == "older")
            {
                filter = (Person x) => x.Age >= compareAge;
            }
            else
            {
                filter = (Person x) => x.Age < compareAge;
            }

            string formatType = Console.ReadLine();

            Action<Person> printer;

            if (formatType == "name age")
            {
                printer = x => Console.WriteLine($"{x.Name} - {x.Age}");
            }
            else if(formatType == "age")
            {
                printer = x => Console.WriteLine($"{x.Age}");
            }
            else
            {
                printer = x => Console.WriteLine($"{x.Name}");
            }

            PrintFilteredPeople(people, filter, printer);
        }

        static void PrintFilteredPeople(Person[] people, Func<Person, bool> filter, Action<Person> printer)
        {
            Person[] filteredPeople = people.Where(x => filter(x)).ToArray();

            foreach (var person in filteredPeople)
            {
                printer(person);
            }
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
