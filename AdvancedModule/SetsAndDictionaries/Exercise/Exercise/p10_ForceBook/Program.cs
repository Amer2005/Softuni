using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10_ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, string> UserAndSide = new Dictionary<string, string>();

            Dictionary<string, List<string>> SideAndUserInIt = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
                {
                    //add user

                    string[] inputArgs = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string side = inputArgs[0];
                    string user = inputArgs[1];

                    if (UserAndSide.ContainsKey(user))
                    {
                        continue;
                    }

                    UserAndSide.Add(user, side);

                    if (SideAndUserInIt.ContainsKey(side))
                    {
                        SideAndUserInIt[side].Add(user);
                    }
                    else
                    {
                        SideAndUserInIt.Add(side, new List<string> { user });
                    }
                }
                else
                {
                    string[] inputArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string side = inputArgs[1];
                    string user = inputArgs[0];

                    if (!UserAndSide.ContainsKey(user))
                    {
                        UserAndSide.Add(user, side);

                        if (SideAndUserInIt.ContainsKey(side))
                        {
                            SideAndUserInIt[side].Add(user);
                        }
                        else
                        {
                            SideAndUserInIt.Add(side, new List<string> { user });
                        }

                        Console.WriteLine($"{user} joins the {side} side!");

                        continue;
                    }

                    SideAndUserInIt[UserAndSide[user]].Remove(user);

                    UserAndSide[user] = side;

                    if (!SideAndUserInIt.ContainsKey(side))
                    {
                        SideAndUserInIt[side] = new List<string>();
                    }

                    SideAndUserInIt[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            foreach (var SideAndUsersPair in SideAndUserInIt.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if(SideAndUsersPair.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {SideAndUsersPair.Key}, Members: {SideAndUsersPair.Value.Count}");

                foreach (string user in SideAndUsersPair.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
