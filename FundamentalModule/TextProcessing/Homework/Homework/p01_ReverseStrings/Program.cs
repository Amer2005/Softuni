using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                char[] reverse = input.ToCharArray();

                Array.Reverse(reverse);

                Console.WriteLine($"{input} = {new string(reverse)}");
            }
        }
    }
}
