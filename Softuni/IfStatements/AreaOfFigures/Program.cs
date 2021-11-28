using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();

            double area = 0;

            if(shape == "square")
            {
                double a = double.Parse(Console.ReadLine());

                area = a * a;
            }
            else if(shape == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                area = a * b;
            }
            else if(shape == "circle")
            {
                double r = double.Parse(Console.ReadLine());

                area = r * r * Math.PI;
            }
            else
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                area = a * h / 2;
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
