using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_OrderByAge
{
    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;

            while((input = Console.ReadLine()) != "End")
            {
                string[] personArgs = input.Split(' ');

                string name = personArgs[0];
                string id = personArgs[1];
                int age = int.Parse(personArgs[2]);

                if (people.Any(x => x.Id == id))
                {
                    Person person = people.FirstOrDefault(x => x.Id == id);

                    person.Age = age;
                    person.Name = name;

                    continue;
                }

                people.Add(new Person(name, id, age));
            }

            Console.WriteLine(String.Join("\n", people.OrderBy(x => x.Age)));
        }
    }
}
