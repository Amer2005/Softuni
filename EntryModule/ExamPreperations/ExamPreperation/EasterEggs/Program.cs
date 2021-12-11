using System;

namespace EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEggs = int.Parse(Console.ReadLine());

            int numRed = 0;
            int numOrange = 0;
            int numBlue = 0;
            int numGreen = 0;
            int maxEggs = 0;

            string maxColor = "";

            for (int i = 0; i < numberOfEggs; i++)
            {
                string color = Console.ReadLine();

                if(color == "red")
                {
                    numRed++;

                    if(numRed > maxEggs)
                    {
                        maxEggs = numRed;
                        maxColor = "red";
                    }
                }
                else if (color == "orange")
                {
                    numOrange++;

                    if (numOrange > maxEggs)
                    {
                        maxEggs = numOrange;
                        maxColor = "orange";
                    }
                }
                else if (color == "blue")
                {
                    numBlue++;

                    if (numBlue > maxEggs)
                    {
                        maxEggs = numBlue;
                        maxColor = "blue";
                    }
                }
                else if (color == "green")
                {
                    numGreen++;

                    if (numGreen > maxEggs)
                    {
                        maxEggs = numGreen;
                        maxColor = "green";
                    }
                }
            }

            Console.WriteLine($"Red eggs: {numRed}");
            Console.WriteLine($"Orange eggs: {numOrange}");
            Console.WriteLine($"Blue eggs: {numBlue}");
            Console.WriteLine($"Green eggs: {numGreen}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxColor}");
        }
    }
}
