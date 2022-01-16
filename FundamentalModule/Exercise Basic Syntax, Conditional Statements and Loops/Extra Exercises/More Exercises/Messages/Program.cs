using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfletters = int.Parse(Console.ReadLine());

            StringBuilder message = new StringBuilder();

            for (int i = 0; i < numberOfletters; i++)
            {
                string input = Console.ReadLine();

                message.Append(GetLetter(input));
            }

            Console.WriteLine(message);
        }

        static private char GetLetter(string presses)
        {
            return GetPressLetters(presses[0])[presses.Length - 1];
        }

        static private string GetPressLetters(char press)
        {
            switch (press)
            {
                case '2':
                    return "abc";
                case '3':
                    return "def";
                case '4':
                    return "ghi";
                case '5':
                    return "jkl";
                case '6':
                    return "mno";
                case '7':
                    return "pqrs";
                case '8':
                    return "tuv";
                case '9':
                    return "wxyz";
                default:
                    return " ";
            }
        }
    }
}
