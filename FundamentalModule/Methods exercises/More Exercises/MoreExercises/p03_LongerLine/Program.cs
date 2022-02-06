using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_LongerLine
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

        public class Line
        {
            public Point FirstPoint { get; set; }
            public Point SecondPoint { get; set; }

            public double Lenght { get; set; }

            public Line(Point firstPoint, Point secondPoint)
            {
                FirstPoint = firstPoint;
                SecondPoint = secondPoint;

                if (GetDistanceFromCenter(FirstPoint) > GetDistanceFromCenter(SecondPoint))
                {
                    Point temp = new Point(FirstPoint.X, FirstPoint.Y);

                    FirstPoint = new Point(SecondPoint.X, SecondPoint.Y);
                    SecondPoint = new Point(temp.X, temp.Y);
                }
            }

            public override string ToString()
            {
                return $"{FirstPoint}{SecondPoint}";
            }
        }

        static void Main(string[] args)
        {
            double x1_1 = double.Parse(Console.ReadLine());
            double y1_1 = double.Parse(Console.ReadLine());
            double x2_1 = double.Parse(Console.ReadLine());
            double y2_1 = double.Parse(Console.ReadLine());

            double x1_2 = double.Parse(Console.ReadLine());
            double y1_2 = double.Parse(Console.ReadLine());
            double x2_2 = double.Parse(Console.ReadLine());
            double y2_2 = double.Parse(Console.ReadLine());

            Line firstLine = new Line(new Point(x1_1, y1_1), new Point(x2_1, y2_1));
            Line secondLine = new Line(new Point(x1_2, y1_2), new Point(x2_2, y2_2));

            firstLine.Lenght = GetDistanceBetweenPoints(firstLine.FirstPoint, firstLine.SecondPoint);
            secondLine.Lenght = GetDistanceBetweenPoints(secondLine.FirstPoint, secondLine.SecondPoint);

            if(firstLine.Lenght > secondLine.Lenght)
            {
                Console.WriteLine(firstLine);
            }
            else
            {
                Console.WriteLine(secondLine);
            }
        }

        static double GetDistanceBetweenPoints(Point firstPoint, Point secondPoint)
        {
            double distance = Math.Sqrt(Math.Pow(secondPoint.X - firstPoint.X, 2) + Math.Pow(secondPoint.Y - firstPoint.Y, 2));

            return distance;
        }

        static double GetDistanceFromCenter(Point point)
        {
            return GetDistanceBetweenPoints(point, new Point(0, 0));
        }
    }
}
