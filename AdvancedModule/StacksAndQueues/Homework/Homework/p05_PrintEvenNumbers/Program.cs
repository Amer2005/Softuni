using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(
                Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x % 2 == 0));

            while (queue.Count > 0)
            {
                if (queue.Count != 1)
                {
                    Console.Write($"{queue.Dequeue()}, ");
                }
                else
                {
                    Console.Write($"{queue.Dequeue()}");
                }
            }

            Console.WriteLine();
        }
    }
}
