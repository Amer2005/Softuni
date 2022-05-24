using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_AvarageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsAndGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] inputArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];

                decimal grade = decimal.Parse(inputArgs[1]);

                if (studentsAndGrades.ContainsKey(name))
                {
                    studentsAndGrades[name].Add(grade);
                }
                else
                {
                    studentsAndGrades[name] = new List<decimal> {grade};
                }
            }

            foreach (var keyValuePair in studentsAndGrades)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {string.Join(" ", keyValuePair.Value.Select(x => $"{x:f2}"))} (avg: {keyValuePair.Value.Average():f2})");
            }
        }
    }
}
