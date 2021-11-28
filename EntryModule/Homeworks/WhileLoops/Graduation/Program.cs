using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double totalGrade = 0;

            double avarageGrade = 0;

            int timesFailed = 0;

            for (int i = 1; i <= 12; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                totalGrade += grade;

                avarageGrade = totalGrade / i;

                if(grade < 4)
                {
                    timesFailed++;

                    if (timesFailed >= 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {i - 1} grade");

                        return;
                    }
                }
            }

            Console.WriteLine($"{name} graduated. Average grade: {avarageGrade:f2}");
        }
    }
}
