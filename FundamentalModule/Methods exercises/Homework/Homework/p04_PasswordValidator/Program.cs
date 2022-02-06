using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isPasswordValid = true;

            if (!IsPasswordLenghtValid(password))
            {
                isPasswordValid = false;

                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ArePasswordSpecialSymbolsValid(password))
            {
                isPasswordValid = false;

                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!AreThereEnoughDigits(password))
            {
                isPasswordValid = false;

                Console.WriteLine("Password must have at least 2 digits");
            }


            if (isPasswordValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsPasswordLenghtValid(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            return false;
        }

        static bool ArePasswordSpecialSymbolsValid(string password)
        {
            foreach (char ch in password)
            {
                if (!IsWordOrDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsWordOrDigit(char letter)
        {
            letter = Char.ToLower(letter);

            if (letter >= 'a' && letter <= 'z')
            {
                return true;
            }

            if (letter >= '0' && letter <= '9')
            {
                return true;
            }

            return false;
        }

        static bool AreThereEnoughDigits(string password)
        {
            int numberOfDigits = password.Where(x => x >= '0' && x <= '9').Count();

            if (numberOfDigits >= 2)
            {
                return true;
            }

            return false;
        }
    }
}
