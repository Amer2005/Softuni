using System;
using System.Collections.Generic;
using System.Text;

namespace p01_ClassBoxData
{
    public class Box
    {
        private const double BoxSizeMinValue = 0;

        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Length = lenght;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get 
            { 
                return this.length; 
            }
            private set
            {
                if (value <= BoxSizeMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= BoxSizeMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= BoxSizeMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public double SurfaceArea()
        {
            return 2 * (Length * Width + Length * Height + Height * Width);
        }

        public double LateralSurfaceArea()
        {
            return 2 * Height * (Length + Width);
        }

        public double Volume()
        {
            return Height * Width * Length;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {this.Volume():f2}");

            return result.ToString().TrimEnd();
        }
    }
}
