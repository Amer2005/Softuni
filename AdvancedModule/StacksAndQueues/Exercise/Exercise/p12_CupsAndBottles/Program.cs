using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p12_CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse));

            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse));

            int cupNow = cups.Dequeue();

            int wastedWater = 0;

            while(true)
            {
                int bottleNow = bottles.Pop();

                cupNow -= bottleNow;

                if (cupNow <= 0)
                {
                    wastedWater += -cupNow;

                    if(cups.Count == 0)
                    {
                        break;
                    }

                    cupNow = cups.Dequeue();
                }

                if (bottles.Count == 0)
                {
                    break;
                }
            }

            if (cups.Count == 0 && cupNow <= 0)
            {
                Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {cupNow} {String.Join(" ", cups.ToArray())}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
