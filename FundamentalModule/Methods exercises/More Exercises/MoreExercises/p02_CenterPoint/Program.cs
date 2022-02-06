using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_CenterPoint
{
    internal class Program
    {
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }

        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Point firstPoint = new Point(x1, y1);
            Point secondPoint = new Point(x2, y2);

            Console.WriteLine(GetClosesedPointToCenter(firstPoint, secondPoint));
        }

        static Point GetClosesedPointToCenter(Point firstPoint, Point secondPoint)
        {
            if(GetDistanceBetweenPoints(firstPoint, new Point(0, 0)) <= 
               GetDistanceBetweenPoints(secondPoint, new Point(0, 0)))
            {
                return firstPoint;
            }

            return secondPoint;
        }

        static double GetDistanceBetweenPoints(Point firstPoint, Point secondPoint)
        {
            double distance = Math.Sqrt(Math.Pow(secondPoint.X - firstPoint.X, 2) + Math.Pow(secondPoint.Y - firstPoint.Y, 2));

            return distance;
        }
    }
}
