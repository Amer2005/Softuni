using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
                
                string course = commands[0];

                string name = commands[1];

                if (courses.ContainsKey(course))
                {
                    courses[course].Add(name);
                }
                else
                {
                    courses.Add(course, new List<string> { name });
                }
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var name in course.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
