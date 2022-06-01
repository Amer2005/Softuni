using System;
using System.Collections.Generic;
using System.Linq;

namespace p10_PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ').ToList();

            string input;

            List<string> filtersAsStrings = new List<string>();

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] splittedInput = input.Split(';');

                string actionType = splittedInput[0];
                string filterType = splittedInput[1];
                string filterParam = splittedInput[2];

                if (actionType == "Add filter")
                {
                    filtersAsStrings.Add(filterType + ";" + filterParam);
                }
                else
                {
                    filtersAsStrings.RemoveAll(filter => filter == filterType + ";" + filterParam);
                }
            }

            foreach (string filterString in filtersAsStrings)
            {
                string[] splittedFilter = filterString.Split(';');

                string filterType = splittedFilter[0];
                string filterParam = splittedFilter[1];

                Predicate<string> filter;

                if (filterType == "Starts with")
                {
                    filter = x => x.StartsWith(filterParam);
                }
                else if (filterType == "Ends with")
                {
                    filter = x => x.EndsWith(filterParam);
                }
                else if (filterType == "Lenght")
                {
                    filter = x => x.Length == int.Parse(filterParam);
                }
                else
                {
                    filter = x => x.Contains(filterParam);
                }

                people = people.FindAll(x => !filter(x));
            }

            Console.WriteLine(String.Join(" ", people));
        }
    }
}
