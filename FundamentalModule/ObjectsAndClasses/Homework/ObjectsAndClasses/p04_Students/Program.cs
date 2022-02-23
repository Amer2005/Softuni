using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_Students
{
    internal class Program
    {
        public class Student
        {
            public string FirstName { get; set; }

            public string SecondName { get; set; }

            public int Age { get; set; }

            public string HomeTown { get; set; }

            public Student(string firstName, string secondName, int age, string homeTown)
            {
                FirstName = firstName;
                SecondName = secondName;
                Age = age;
                HomeTown = homeTown;
            }

            public override string ToString()
            {
                return $"{FirstName} {SecondName} is {Age} years old.";
            }
        }

        static void Main(string[] args)
        {
            string input;

            List<Student> students = new List<Student>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split(' ');

                students.Add(new Student(inputs[0], inputs[1], int.Parse(inputs[2]), inputs[3]));
            }

            string city = Console.ReadLine();

            Console.WriteLine(String.Join(Environment.NewLine, students.Where(x => x.HomeTown == city)));
        }
    }
}
