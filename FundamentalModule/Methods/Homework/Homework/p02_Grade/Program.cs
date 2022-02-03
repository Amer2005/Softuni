using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine((GetGradeName(grade)));
        }

        static string GetGradeName(double grade)
        {
            if (grade < 3)
            {
                return "Fail";
            }

            if (grade < 3.5)
            {
                return "Poor";
            }

            if (grade < 4.5)
            {
                return "Good";
            }

            if (grade < 5.5)
            {
                return "Very good";
            }

            return "Excellent";
        }
    }
}
