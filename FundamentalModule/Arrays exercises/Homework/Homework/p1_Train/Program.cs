using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());

            int[] wagons = new int[numberOfWagons];

            for (int i = 0; i < numberOfWagons; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                Console.Write($"{wagons[i]} ");
                sum += wagons[i];
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
