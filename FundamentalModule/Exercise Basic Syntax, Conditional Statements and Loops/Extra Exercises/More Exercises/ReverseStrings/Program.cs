using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            string reversedString = new string(str.Reverse().ToArray());

            Console.WriteLine(reversedString);
        }
    }
}
