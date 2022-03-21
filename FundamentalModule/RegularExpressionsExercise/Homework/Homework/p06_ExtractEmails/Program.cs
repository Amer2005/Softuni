using System;
using System.Text.RegularExpressions;

namespace p06_ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"[\s^](?<user>[A-Za-z0-9][\w.\-_]*[A-Za-z0-9])@(?<host>[A-Za-z][A-Za-z-\.]*[A-Za-z]\.([A-Za-z][A-Za-z-\.]*[A-Za-z])+)");
            
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value.Trim());
            }
        }
    }
}
