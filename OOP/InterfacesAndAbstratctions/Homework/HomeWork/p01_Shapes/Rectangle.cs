using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Console.WriteLine(MakeLine(width, '*', '*'));

            for (int i = 0; i < height - 2; i++)
            {
                Console.WriteLine(MakeLine(width, ' ', '*'));
            }

            Console.WriteLine(MakeLine(width, '*', '*'));
        }

        public string MakeLine(int lenght, char middle, char end)
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
