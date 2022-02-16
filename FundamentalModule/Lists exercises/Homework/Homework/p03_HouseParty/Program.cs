using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();

            string input;

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                input = Console.ReadLine();

                string[] actionArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (actionArgs.Length == 3)
                {
                    string name = actionArgs[0];

                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");

                        continue;
                    }

                    guests.Add(name);
                }
                else if (actionArgs.Length == 4)
                {
                    string name = actionArgs[0];

                    if (!guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");

                        continue;
                    }

                    guests.Remove(name);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine , guests));
        }
    }
}
