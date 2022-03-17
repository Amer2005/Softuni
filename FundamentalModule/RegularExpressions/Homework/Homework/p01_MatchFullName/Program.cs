using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p01_MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string text = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(text, regex);

            foreach (Match names in matchedNames)
            {
                Console.Write($"{names.Value} ");
            }
            Console.WriteLine();
        }
    }
}
