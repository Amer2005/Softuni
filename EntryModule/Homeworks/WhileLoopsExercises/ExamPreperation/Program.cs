using System;

namespace ExamPreperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFails = int.Parse(Console.ReadLine());
            int fails = 0;

            string lastExerciseName = "";

            string exerciseName = Console.ReadLine();

            int numberOfProblems = 0;

            double totalGrade = 0;

            double avarageGrade = 0;

            while(exerciseName != "Enough")
            {
                double exerciseGrade = double.Parse(Console.ReadLine());

                totalGrade += exerciseGrade;

                numberOfProblems++;

                avarageGrade = totalGrade / numberOfProblems;

                if(exerciseGrade <= 4)
                {
                    fails++;

                    if(fails >= maxFails)
                    {
                        Console.WriteLine($"You need a break, {fails} poor grades.");

                        return;
                    }
                }

                lastExerciseName = exerciseName;

                exerciseName = Console.ReadLine();
            }

            Console.WriteLine($"Average score: {avarageGrade :f2}");
            Console.WriteLine($"Number of problems: {numberOfProblems}");
            Console.WriteLine($"Last problem: {lastExerciseName}");
        }
    }
}
