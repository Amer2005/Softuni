using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_Students
{
    public class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Student[] students = new Student[numberOfStudents];

            for (int i = 0; i < numberOfStudents; i++)
            {
                string input = Console.ReadLine();

                string[] commands = input.Split(' ');

                string firstName = commands[0];
                string lastName = commands[1];
                double grade = double.Parse(commands[2]);

                students[i] = new Student(firstName, lastName, grade);
            }

            students = students.OrderByDescending(x => x.Grade).ToArray();

            Console.WriteLine(String.Join("\n", students.ToList()));
        }
    }
}
