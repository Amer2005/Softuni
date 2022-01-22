using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int tank = 0;

            for (int i = 0; i < n; i++)
            {
                int water = int.Parse(Console.ReadLine());

                if (tank + water > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    tank += water;
                }
            }

            Console.WriteLine(tank);
        }
    }
}
