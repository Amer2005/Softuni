using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_TeamworkProjects
{
    public class Team
    {
        public Team(string teamName, string creatorName)
        {
            Name = teamName;
            Creator = creatorName;

            Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            Members.Add(member);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(Name);

            result.AppendLine($"- {Creator}");

            Members = Members.OrderBy(x => x).ToList();

            foreach (var member in Members)
            {
                result.AppendLine($"-- {member}");
            }

            return result.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamArgs = Console.ReadLine().Split(new char[] {'-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string creatorName = teamArgs[0];
                string teamName = teamArgs[1];

                if (teams.Select(x => x.Name).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");

                    continue;
                }

                if(teams.Select(x => x.Creator).Contains(creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");

                    continue;
                }

                teams.Add(new Team(teamName, creatorName));

                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }

            string input;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] memberArgs = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string memberName = memberArgs[0];
                string teamName = memberArgs[1];

                if (!teams.Select(x => x.Name).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");

                    continue;
                }

                if (teams.Where(x => x.Members.Contains(memberName) || x.Creator == memberName).Count() > 0)
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");

                    continue;
                }

                int teamIndex = teams.IndexOf(teams.FirstOrDefault(x => x.Name == teamName));

                teams[teamIndex].AddMember(memberName);
            }

            Team[] teamsToDisband = teams.Where(x => x.Members.Count() <= 0).OrderBy(x => x.Name).ToArray();

            teams = teams.Where(x => x.Members.Count() > 0)
                            .OrderByDescending(x => x.Members.Count())
                            .ThenBy(x => x.Name)
                            .ToList();

            Console.Write(String.Join("", teams));

            Console.WriteLine("Teams to disband:");

            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
