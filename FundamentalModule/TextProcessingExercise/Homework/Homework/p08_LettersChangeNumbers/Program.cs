using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (var numberWithLetters in numbers)
            {
                sum += GetNumber(numberWithLetters);
            }

            Console.WriteLine($"{sum:f2}");
        }

        static double GetNumber(string numberWithLetters)
        {
            double number = double.Parse(numberWithLetters.Substring(1, numberWithLetters.Length - 2));

            char firstLetter = numberWithLetters[0];
            char secondLetter = numberWithLetters[numberWithLetters.Length - 1];

            if(char.IsUpper(firstLetter))
            {
                number /= (firstLetter - 'A' + 1);
            }
            else
            {
                number *= (firstLetter - 'a' + 1);
            }

            if (char.IsUpper(secondLetter))
            {
                number -= (secondLetter - 'A' + 1);
            }
            else
            {
                number += (secondLetter - 'a' + 1);
            }

            return number;
        }
    }
}
