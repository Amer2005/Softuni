using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_Songs
{
    public class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }

        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            Song[] songs = new Song[numberOfSongs];   

            for (int i = 0; i < numberOfSongs; i++)
            {
                string input = Console.ReadLine();
                string[] inputs = input.Split('_');

                songs[i] = new Song(inputs[0], inputs[1], inputs[2]);
            }

            string action = Console.ReadLine();

            if (action == "all")
            {
                Console.WriteLine(string.Join("\n", songs.ToList()));
            }
            else
            {
                Console.WriteLine(string.Join("\n", songs.Where(x => x.TypeList == action)));
            }
        }
    }
}
