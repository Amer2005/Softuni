using System;
using System.Collections.Generic;
using System.Linq;

namespace p09_PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ').ToList();

            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] splittedInput = input.Split(' ');

                string actionType = splittedInput[0];
                string filterType = splittedInput[1];

                Func<List<string>, Predicate<string>, List<string>> action;

                if (actionType == "Remove")
                {
                    action = (List<string> list, Predicate<string> filter) => list.FindAll(x => !filter(x));
                }
                else
                {
                    action = (List<string> list, Predicate<string> filter) =>
                    {
                        List<string> newList = new List<string>();

                        foreach (var name in list)
                        {
                            newList.Add(name);

                            if (filter(name))
                            {
                                newList.Add(name);
                            }
                        }

                        return newList;
                    };
                }

                Predicate<string> filter;

                if (filterType == "StartsWith")
                {
                    string start = splittedInput[2];

                    filter = x => x.StartsWith(start);
                }
                else if (filterType == "EndsWith")
                {
                    string end = splittedInput[2];

                    filter = x => x.EndsWith(end);
                }
                else
                {
                    int lenght = int.Parse(splittedInput[2]);

                    filter = x => x.Length == lenght;
                }

                people = action(people, filter);
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", people) + " are going to the party!");
            }
        }
    }
}
