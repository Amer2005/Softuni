using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;

            int numberOfGuesses = 0;

            while((command = Console.ReadLine()) != "end")
            {
                numberOfGuesses++;

                string[] commands = command.Split(' ');

                int firstIndex = int.Parse(commands[0]);
                int secondIndex = int.Parse(commands[1]);

                if(firstIndex == secondIndex || 
                   firstIndex < 0 || secondIndex < 0 ||
                   firstIndex >= values.Count || secondIndex >= values.Count)
                {
                    PenalisePlayer(values, numberOfGuesses);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (values[firstIndex] == values[secondIndex])
                {
                    string valueNow = values[firstIndex];

                    Console.WriteLine($"Congrats! You have found matching elements - {valueNow}!");

                    values.Remove(valueNow);
                    values.Remove(valueNow);
                }
                else
                {
                    Console.WriteLine($"Try again!");
                }

                if (values.Count == 0)
                {
                    break;
                }
            }

            if (values.Count == 0)
            {
                Console.WriteLine($"You have won in {numberOfGuesses} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(String.Join(" ", values));
            }
        }

        static void PenalisePlayer(List<string> values, int numberOfMoves)
        {
            string valueNow = $"-{numberOfMoves}a";

            values.Insert(values.Count / 2, valueNow);
            values.Insert(values.Count / 2, valueNow);
        }
    }
}
