using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int nextLine = 1;

            int rows = 1;

            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");

                if(i == nextLine)
                {
                    Console.WriteLine();

                    nextLine = rows + i + 1;

                    rows++;
                }
            }
        }
    }
}
