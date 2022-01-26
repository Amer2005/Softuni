using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                double roundedNumber = Math.Round(array[i], MidpointRounding.AwayFromZero);
                
                Console.WriteLine($"{array[i]} => {roundedNumber}");
            }
        }
    }
}
