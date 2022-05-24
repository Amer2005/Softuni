using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();

            for (int i = 0; i < 3; i++)
            {
                if (i >= array.Length)
                {
                    break;
                }

                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
