using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return (Width + Height) * 2;
        }

        public override string Draw()
        {
            int newWidth = (int)Math.Round(Width);
            int newHeight = (int)Math.Round(Height);

            StringBuilder result = new StringBuilder();
            result.AppendLine(MakeLine(newWidth, '*', '*'));

            for (int i = 0; i < newHeight - 2; i++)
            {
                result.AppendLine(MakeLine(newWidth, ' ', '*'));
            }

            result.AppendLine(MakeLine(newWidth, '*', '*'));

            return result.ToString().TrimEnd();
        }

        public string MakeLine(double lenght, char middle, char end)
        {
            StringBuilder result = new StringBuilder();

            result.Append(end);

            for (int i = 0; i < lenght - 2; i++)
            {
                result.Append(middle);
            }

            result.Append(end);

            return result.ToString();
        }
    }
}
