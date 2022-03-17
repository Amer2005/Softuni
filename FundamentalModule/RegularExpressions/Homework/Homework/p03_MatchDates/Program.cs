using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p03_MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //\b(?<day>\d{2})(?<seperator>[-.\/])(?<month>[A-Z][a-z]+)\2(?<year>\d{4})

            string regex = @"\b(?<day>\d{2})(?<seperator>[-.\/])(?<month>[A-Z][a-z]+)\2(?<year>\d{4})";

            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, regex);

            string[] matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(m => $"Day: {m.Groups["day"]}, Month: {m.Groups["month"]}, Year: {m.Groups["year"]}")
                .ToArray();

            Console.WriteLine(String.Join("\n", matchedPhones));
        }
    }
}
