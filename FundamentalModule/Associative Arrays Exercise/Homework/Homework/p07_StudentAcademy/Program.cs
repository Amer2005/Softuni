using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

            int numberOfGrades = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfGrades; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                
                if (grades.ContainsKey(name))
                {
                    grades[name].Add(grade);
                }
                else
                {
                    grades.Add(name, new List<double> { grade });
                }
            }

            foreach (var nameGradePair in grades)
            {
                if (nameGradePair.Value.Average() < 4.5)
                {
                    continue;
                }

                Console.WriteLine($"{nameGradePair.Key} -> {nameGradePair.Value.Average():f2}");
            }
        }
    }
}
