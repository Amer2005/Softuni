using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Contest> NameContest = new Dictionary<string, Contest>();

            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputArgs = input.Split(':');

                string contestName = inputArgs[0];
                string contestPassword = inputArgs[1];

                if (!NameContest.ContainsKey(contestName))
                {
                    NameContest.Add(contestName, new Contest(contestName, contestPassword));
                }
            }

            Dictionary<string, User> NameUser = new Dictionary<string, User>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputArgs = input
                    .Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contestName = inputArgs[0];
                string contestPassword = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (NameContest.ContainsKey(contestName) && NameContest[contestName].Password == contestPassword)
                {
                    if (!NameContest[contestName].UsersAndPoints.ContainsKey(username))
                    {
                        if(NameUser.ContainsKey(username))
                        {
                            NameUser[username].ContestsAndPoints.Add(contestName, points);
                        }
                        else
                        {
                            NameUser.Add(username, new User(username));

                            NameUser[username].ContestsAndPoints.Add(contestName, points);
                        }

                        NameContest[contestName].UsersAndPoints.Add(username, points);
                    }
                    else
                    {
                        NameContest[contestName].UsersAndPoints[username] = Math.Max(NameContest[contestName].UsersAndPoints[username], points);

                        NameUser[username].ContestsAndPoints[contestName] = Math.Max(NameContest[contestName].UsersAndPoints[username], points);
                    }

                    continue;
                }
            }

            User BestUser = NameUser.Select(x => x.Value).OrderByDescending(x => x.ContestsAndPoints.Select(cp => cp.Value).Sum()).ToArray()[0];

            Console.WriteLine($"Best candidate is {BestUser.Name} with total {BestUser.ContestsAndPoints.Select(x => x.Value).Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var NameUserPair in NameUser.OrderBy(x => x.Value.Name))
            {
                Console.WriteLine(NameUserPair.Value.Name);

                foreach (var ContestPointsPair in NameUserPair.Value.ContestsAndPoints.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {ContestPointsPair.Key} -> {ContestPointsPair.Value}");
                }
            }
        }

        public class User
        {
            public User(string name)
            {
                Name = name;
                ContestsAndPoints = new Dictionary<string, int>();
            }

            public string Name { get; set; }


            public Dictionary<string, int> ContestsAndPoints;
        }

        public class Contest
        {
            public Contest(string name, string password)
            {
                Name = name;
                Password = password;
                UsersAndPoints = new Dictionary<string, int>();
            }

            public string Name { get; set; }

            public string Password { get; set; }

            public Dictionary<string, int> UsersAndPoints;
        }
    }
}
