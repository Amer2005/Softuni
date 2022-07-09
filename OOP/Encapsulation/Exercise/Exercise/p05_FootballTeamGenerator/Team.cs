using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p05_FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public int Rating => (int)Math.Round(players.Count == 0 ? 0 : players.Average(x => x.Skill));

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!players.Any(x => x.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            Player player = players.FirstOrDefault(x => x.Name == playerName);

            players.Remove(player);
        }
    }
}
