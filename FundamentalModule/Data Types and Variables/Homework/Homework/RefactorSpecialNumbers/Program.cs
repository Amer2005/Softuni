using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int numberNow = i;
                
                while (numberNow > 0)
                {
                    sum += numberNow % 10;
                    numberNow = numberNow / 10;
                }

                bool isSpecial = false;
                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                
                Console.WriteLine("{0} -> {1}", i, isSpecial);
                
                sum = 0;
            }

        }
    }
}
