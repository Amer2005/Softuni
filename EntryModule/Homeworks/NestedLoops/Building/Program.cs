using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());

            int rooms = int.Parse(Console.ReadLine());

            for (int floor = floors; floor >= 1; floor--)
            {
                char roomType = 'L';

                if(floor == floors)
                {
                    roomType = 'L';
                }
                else if(floor % 2 == 0)
                {
                    roomType = 'O';
                }
                else
                {
                    roomType = 'A';
                }

                for (int room = 0; room < rooms; room++)
                {
                    Console.Write($"{roomType}{floor}{room} ");
                }
                Console.WriteLine();
            }
        }
    }
}
