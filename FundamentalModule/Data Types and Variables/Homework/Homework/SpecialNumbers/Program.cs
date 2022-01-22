using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i} -> {IsSpecial(i)}");
            }
        }

        private static bool IsSpecial(int number)
        {
            int sum = 0;

            while(number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum == 5 || sum == 7 || sum == 11)
            {
                return true;
            }

            return false;
        }
    }
}
