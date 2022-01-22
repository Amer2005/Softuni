using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = Console.ReadLine()[0];

            if(letter >= 'A' && letter <= 'Z')
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
