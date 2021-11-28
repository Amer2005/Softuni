using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string review = Console.ReadLine();

            double price = 0;

            double discount = 0;

            double totalPrice = 0;

            if(room == "room for one person")
            {
                price = 18;
            }
            else if(room == "apartment")
            {
                price = 25;

                if(days < 10)
                {
                    discount = 30;
                }
                else if(days <= 15)
                {
                    discount = 35;
                }
                else
                {
                    discount = 50;
                }
            }
            else
            {
                price = 35;

                if (days < 10)
                {
                    discount = 10;
                }
                else if (days <= 15)
                {
                    discount = 15;
                }
                else
                {
                    discount = 20;
                }
            }

            totalPrice = price * (days - 1) * (100 - discount) / 100;

            if(review == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.1;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
