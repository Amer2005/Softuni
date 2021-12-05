using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juries = int.Parse(Console.ReadLine());

            string presentationName = Console.ReadLine();

            double totalAvarage = 0;

            double totalGrade = 0;

            int numberOfStudents = 0;

            while(presentationName != "Finish")
            {
                double avarageNow = 0;

                for (int i = 0; i < juries; i++)
                {
                    double grade = double.Parse(Console.ReadLine());

                    avarageNow += grade;

                    totalGrade += grade;

                    numberOfStudents++;
                }

                avarageNow /= juries;

                Console.WriteLine($"{presentationName} - {avarageNow:f2}.");

                presentationName = Console.ReadLine();
            }

            totalAvarage = totalGrade / numberOfStudents;

            Console.WriteLine($"Student's final assessment is {totalAvarage:f2}.");
        }
    }
}
