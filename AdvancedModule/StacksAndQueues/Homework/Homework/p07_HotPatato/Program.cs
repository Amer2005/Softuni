using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_HotPatato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split(' '));

            int removeCount = int.Parse(Console.ReadLine());

            int countNow = 1;

            while (players.Count > 1)
            {
                if(countNow == removeCount)
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");

                    countNow = 1;
                }
                else
                {
                    players.Enqueue(players.Dequeue());
                    countNow++;
                }
            }

            Console.WriteLine("Last is {0}", players.Peek());
        }
    }
}
