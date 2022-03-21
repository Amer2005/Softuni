using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p02_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> contestantsNames = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Contestant> contestants = new List<Contestant>();

            foreach (var contestantName in contestantsNames)
            {
                contestants.Add(new Contestant(contestantName, 0));
            }

            string input;

            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder name = new StringBuilder();
                int numberOfKmRan = 0;

                for (int i = 0;  i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]))
                    {
                        name.Append(input[i]);
                    }
                    else if (char.IsDigit(input[i]))
                    {
                        numberOfKmRan += input[i] - '0';
                    }
                }

                if (contestants.Any(c => c.Name == name.ToString()))
                {
                    int contestantIndex = contestants
                        .FindIndex(c => c.Name == name.ToString());

                    contestants[contestantIndex].DistanceRan += numberOfKmRan;
                }
            }

            contestants = contestants.OrderByDescending(x => x.DistanceRan).ToList();

            //1st place: { first racer}
            //2nd place: { second racer}
            //3rd place: { third racer}


            Console.WriteLine($"1st place: {contestants[0].Name}");
            Console.WriteLine($"2nd place: {contestants[1].Name}");
            Console.WriteLine($"3rd place: {contestants[2].Name}");
        }
    }

    public class Contestant
    {
        public Contestant(string name, int distanceRan)
        {
            Name = name;
            DistanceRan = distanceRan;
        }

        public string Name { get; set; }

        public int DistanceRan { get; set; }
    }
}
