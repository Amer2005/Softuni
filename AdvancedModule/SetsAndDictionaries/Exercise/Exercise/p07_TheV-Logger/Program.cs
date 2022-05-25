using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArgs = input.Split(' ');

                string action = inputArgs[1];

                if (action == "joined")
                {
                    string userName = inputArgs[0];

                    if(!users.ContainsKey(userName))
                    {
                        users.Add(userName, new User(userName));
                    }
                }
                if (action == "followed")
                {
                    string firstUserName = inputArgs[0];
                    string secondUserName = inputArgs[2];

                    if (firstUserName == secondUserName)
                    {
                        continue;
                    }

                    if (!users.ContainsKey(firstUserName) || !users.ContainsKey(secondUserName))
                    {
                        continue;
                    }

                    if (users[firstUserName].Following.Contains(secondUserName))
                    {
                        continue;
                    }

                    users[firstUserName].Following.Add(secondUserName);

                    users[secondUserName].Followers.Add(firstUserName);
                }
            }

            User[] sortedUsers = users.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count).Select(x => x.Value).ToArray();

            Console.WriteLine($"The V-Logger has a total of {users.Count} vloggers in its logs.");

            Console.WriteLine($"1. {sortedUsers[0]}");

            foreach (var follower in sortedUsers[0].Followers.OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            for (int i = 1; i < sortedUsers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedUsers[i]}");
            }
        }
    }

    public class User
    {
        public User(string name)
        {
            Name = name;
            Followers = new List<string>();
            Following = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Followers { get; set; }

        public List<string> Following { get; set; }

        public override string ToString()
        {
            return $"{Name} : {Followers.Count} followers, {Following.Count} following";
        }
    }
}
/*
Light | Gosho
Dark | Pesho 
Pesho -> SoftUni 
Gosho -> SoftUni 
Lumpawaroo
 */
