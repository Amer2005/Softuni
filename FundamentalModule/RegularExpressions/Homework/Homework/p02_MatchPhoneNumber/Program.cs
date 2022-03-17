using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p02_MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359([\s-]+)2\1\d{3}\1\d{4}\b";

            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, regex);

            string[] matchedPhones = phoneMatches.Cast<Match>().Select(m => m.Value).ToArray();

            Console.WriteLine(String.Join(", ", matchedPhones));
        }
    }
}
