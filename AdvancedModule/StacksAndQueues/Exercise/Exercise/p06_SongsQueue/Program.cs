using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));

            while (songs.Count > 0)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(' ');

                string command = inputArgs[0];

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
                else if (command == "Add")
                {
                    string song = input.Substring("Add ".Length, input.Length - "Add ".Length);

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");

                        continue;
                    }

                    songs.Enqueue(song);
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
