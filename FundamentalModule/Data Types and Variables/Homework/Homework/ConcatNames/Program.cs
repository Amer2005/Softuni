using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcatNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            result.Append(firstName);
            result.Append(delimiter);
            result.Append(secondName);

            Console.WriteLine(result);
        }
    }
}
