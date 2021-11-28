using System;

namespace HotelRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();

            int numberOfNights = int.Parse(Console.ReadLine());

            double priceStudio = 0;

            double discountStudio = 0;

            double priceApartment = 0;

            double discountApratment = 0;


            if(month == "May" || month == "October")
            {
                priceStudio = 50;
                priceApartment = 65;

                if(numberOfNights > 14)
                {
                    discountStudio = 30;
                }
                else if(numberOfNights > 7)
                {
                    discountStudio = 5;
                }
            }
            else if(month == "June" || month == "September")
            {
                priceStudio = 75.2;
                priceApartment = 68.7;

                if(numberOfNights > 14)
                {
                    discountStudio = 20;
                }
            }
            else
            {
                priceStudio = 76;
                priceApartment = 77;
            }

            if(numberOfNights > 14)
            {
                discountApratment = 10;
            }

            priceApartment = priceApartment * numberOfNights * (100 - discountApratment) / 100;
            priceStudio = priceStudio * numberOfNights * (100 - discountStudio) / 100;

            Console.WriteLine($"Apartment: {priceApartment:f2} lv.");
            Console.WriteLine($"Studio: {priceStudio:f2} lv.");
        }
    }
}
