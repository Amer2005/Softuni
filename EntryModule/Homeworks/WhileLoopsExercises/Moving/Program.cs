using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int size = n * m * h;

            while(size >= 0)
            {
                string input = Console.ReadLine();

                if(input == "Done")
                {
                    Console.WriteLine($"{size} Cubic meters left.");

                    return;
                }

                int boxes = int.Parse(input);

                size -= boxes;
            }

            Console.WriteLine($"No more free space! You need {-size} Cubic meters more.");
        }
    }
}
