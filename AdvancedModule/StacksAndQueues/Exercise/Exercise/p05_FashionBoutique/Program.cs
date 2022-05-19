using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
               .Split(' ')
               .Select(int.Parse));

            int rackSize = int.Parse(Console.ReadLine());

            int currentRack = 0;

            int numberOfRacks = 1;

            while(clothes.Count != 0)
            {
                int clothingNow = clothes.Pop();

                if (currentRack + clothingNow <= rackSize)
                {
                    currentRack += clothingNow;
                }
                else
                {
                    numberOfRacks++;
                    currentRack = clothingNow;
                }
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}
