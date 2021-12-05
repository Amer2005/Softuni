using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();

            int kidSeats = 0;
            int studentSeats = 0;
            int standartSeats = 0;

            while (movie != "Finish")
            {
                int seats = int.Parse(Console.ReadLine());

                int numOfSoldSeats = 0;

                for (int i = 1; i <= seats; i++)
                {
                    numOfSoldSeats = i;

                    string seat = Console.ReadLine();

                    if(seat == "End")
                    {
                        numOfSoldSeats--;

                        break;
                    }
                    else if(seat == "kid")
                    {
                        kidSeats++;
                    }
                    else if(seat == "student")
                    {
                        studentSeats++;
                    }
                    else
                    {
                        standartSeats++;
                    }
                }

                Console.WriteLine($"{movie} - {(double)numOfSoldSeats / seats * 100:f2}% full.");

                movie = Console.ReadLine();
            }

            int totalSeats = kidSeats + studentSeats + standartSeats;

            Console.WriteLine($"Total tickets: {kidSeats + studentSeats + standartSeats}");
            Console.WriteLine($"{(double)studentSeats / totalSeats * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)standartSeats / totalSeats * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)kidSeats / totalSeats * 100:f2}% kids tickets.");
        }
    }
}
