using System;
using System.Collections.Generic;
using System.Linq;

namespace p05_FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            List<Team> teams = new List<Team>();

            while ((input = Console.ReadLine()) != "END")
            {
                input = input.Trim();

                string[] inputArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = inputArgs[0];

                if(action == "Team")
                {
                    teams.Add(new Team(inputArgs[1]));
                }
                else if (action == "Add")
                {
                    try
                    {
                        string teamName = inputArgs[1];

                        if(!teams.Any(x => x.Name == teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Team team = teams.FirstOrDefault(x => x.Name == teamName);

                        string playerName = inputArgs[2];
                        int endurance = int.Parse(inputArgs[3]);
                        int sprint = int.Parse(inputArgs[4]);
                        int dribble = int.Parse(inputArgs[5]);
                        int passing = int.Parse(inputArgs[6]);
                        int shooting = int.Parse(inputArgs[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else if (action == "Remove")
                {
                    try
                    {
                        string teamName = inputArgs[1];
                        string playerName = inputArgs[2];

                        if (!teams.Any(x => x.Name == teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Team team = teams.FirstOrDefault(x => x.Name == teamName);

                        team.RemovePlayer(playerName);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }

                }
                else if (action == "Rating")
                {
                    try
                    {
                        string teamName = inputArgs[1];

                        if (!teams.Any(x => x.Name == teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Team team = teams.FirstOrDefault(x => x.Name == teamName);

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }
        }
    }
}
