using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());

            string maxKegName = string.Empty;

            decimal maxKegVolume = decimal.MinValue;

            for (int i = 0; i < numberOfKegs; i++)
            {
                string name = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                decimal volume = (decimal)Math.PI * (decimal)radius * (decimal)radius * height;

                if (maxKegVolume < volume)
                {
                    maxKegName = name;
                    maxKegVolume = volume;
                }
            }

            Console.WriteLine(maxKegName);
        }
    }
}
