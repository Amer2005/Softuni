using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_SoftuniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> LanguageAndNumberOfSubmissions = new Dictionary<string, int>();
            Dictionary<string, double> UserAndPoints = new Dictionary<string, double>();

            string input;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArgs = input.Split('-');

                string user = inputArgs[0];

                if (inputArgs.Length == 2)
                {
                    UserAndPoints.Remove(user);

                    continue;
                }

                string language = inputArgs[1];
                double points = double.Parse(inputArgs[2]);

                if(LanguageAndNumberOfSubmissions.ContainsKey(language))
                {
                    LanguageAndNumberOfSubmissions[language]++;
                }
                else
                {
                    LanguageAndNumberOfSubmissions.Add(language, 1);
                }

                if (UserAndPoints.ContainsKey(user))
                {
                    UserAndPoints[user] = Math.Max(UserAndPoints[user], points);
                }
                else
                {
                    UserAndPoints.Add(user, points);
                }
            }

            Console.WriteLine("Results:");

            foreach (var user in UserAndPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submission in LanguageAndNumberOfSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
