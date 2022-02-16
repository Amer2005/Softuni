using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int maxPeople = int.Parse(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] actionArgs = input.Split(' ');

                if (actionArgs[0] == "Add")
                {
                    int numberOfPeople = int.Parse(actionArgs[1]);

                    numberOfPeople %= (maxPeople + 1);

                    wagons.Add(numberOfPeople);
                }
                else
                {
                    int numberOfPeople = int.Parse(actionArgs[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if(wagons[i] + numberOfPeople <= maxPeople)
                        {
                            wagons[i] += numberOfPeople;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
