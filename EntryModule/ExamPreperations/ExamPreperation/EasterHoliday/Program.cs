using System;

namespace EasterHoliday
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] prices = {{30, 35,  40  },
                             {28, 32,  39 },
                             {32, 37,  43 } };

            string place = Console.ReadLine();

            string date = Console.ReadLine();

            int days = int.Parse(Console.ReadLine());

            int numPlace = 0;

            int numDate = 0;

            if(place == "Italy")
            {
                numPlace = 1;
            }
            else if (place == "Germany")
            {
                numPlace = 2;
            }

            if (date == "24-27")
            {
                numDate = 1;
            }
            else if (date == "28-31")
            {
                numDate = 2;
            }

            int price = prices[numPlace, numDate] * days;

            Console.WriteLine($"Easter trip to {place} : {price:f2} leva.");
        }
    }
}
