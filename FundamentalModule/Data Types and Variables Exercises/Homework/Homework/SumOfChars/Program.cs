using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char ch = char.Parse(Console.ReadLine());

                sum += (int)ch;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
