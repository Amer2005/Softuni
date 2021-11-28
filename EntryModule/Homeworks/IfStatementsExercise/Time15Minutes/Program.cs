using System;

namespace Time15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());

            int minutes = int.Parse(Console.ReadLine());

            minutes += 15;

            hours += minutes / 60;

            minutes %= 60;

            hours %= 24;

            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
