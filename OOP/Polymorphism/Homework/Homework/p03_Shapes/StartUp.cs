using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            Shape circle = new Circle(radius);

            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Shape rectangle = new Rectangle(width, height);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());


        }
    }
}
