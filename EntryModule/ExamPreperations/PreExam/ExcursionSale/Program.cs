using System;

namespace ExcursionSale
{
    class Program
    {
        static void Main(string[] args)
        {
            int seaTrips = int.Parse(Console.ReadLine());

            int mountainTrips = int.Parse(Console.ReadLine());

            string tripType = Console.ReadLine();

            double price = 0;

            while(tripType != "Stop")
            {
                if(tripType == "sea")
                {
                    seaTrips--;

                    if(seaTrips >= 0)
                    {
                        price += 680;
                    }
                }
                else
                {
                    mountainTrips--;

                    if(mountainTrips >= 0)
                    {
                        price += 499;
                    }
                }

                if(seaTrips <= 0 && mountainTrips <= 0)
                {
                    Console.WriteLine("Good job! Everything is sold.");

                    break;
                }

                tripType = Console.ReadLine();
            }

            Console.WriteLine($"Profit: {price} leva.");
        }
    }
}
