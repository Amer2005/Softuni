using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                int number = int.Parse(input);

                if (IsPalindrome(number))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool IsPalindrome(int number)
        {
            int[] digits = GetDigitsOfNumber(number);

            for (int i = 0; i < digits.Length / 2; i++)
            {
                if(digits[i] != digits[digits.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int[] GetDigitsOfNumber(int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }
    }
}
