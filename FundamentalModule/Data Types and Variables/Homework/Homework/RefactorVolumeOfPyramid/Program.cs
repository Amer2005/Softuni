using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");

            double lenght;
            lenght = double.Parse(Console.ReadLine());

            Console.Write("Width: ");

            double width;
            width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");

            double height;
            height = double.Parse(Console.ReadLine());

            double volume;
            volume = (lenght * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
