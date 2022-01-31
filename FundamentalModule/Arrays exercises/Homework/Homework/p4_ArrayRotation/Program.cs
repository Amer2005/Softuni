using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rotations = int.Parse(Console.ReadLine());

            rotations %= array.Length;

            int positionNow = rotations;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[positionNow]} ");

                positionNow++;

                positionNow %= array.Length;
            }
            Console.WriteLine();
        }
    }
}
