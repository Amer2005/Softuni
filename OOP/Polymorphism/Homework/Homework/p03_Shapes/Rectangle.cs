using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The side lenght must be positive!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The side lenght must be positive!");
                }

                this.height = value;
            }
        }

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
            return base.Draw() + this.GetType().Name;
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
