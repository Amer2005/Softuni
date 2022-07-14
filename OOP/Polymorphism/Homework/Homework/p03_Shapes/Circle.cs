using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * Radius * 2;
        }

        public override string Draw()
        {
            int newRadius = (int)Math.Round(Radius);

            double rIn = newRadius - 0.4;
            double rOut = newRadius + 0.4;

            StringBuilder result = new StringBuilder();

            for (double y = newRadius; y >= -newRadius; --y)
            {
                for (double x = -newRadius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        result.Append("*");
                    }
                    else
                    {
                        result.Append(" ");
                    }
                }

                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }
    }
}
