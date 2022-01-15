using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());    
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            if (typeOfGroup == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                }
                else if (day == "Saturday")
                {
                    price = 9.8;
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                }

                totalPrice = price * numberOfPeople;

                if (numberOfPeople >= 30)
                {
                    totalPrice = totalPrice * 0.85;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.9;
                }
                else if (day == "Saturday")
                {
                    price = 15.6;
                }
                else if (day == "Sunday")
                {
                    price = 16;
                }

                totalPrice = price * numberOfPeople;

                if (numberOfPeople >= 100)
                {
                    totalPrice = totalPrice - price * 10;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                }
                else if (day == "Sunday")
                {
                    price = 22.5;
                }

                totalPrice = price * numberOfPeople;

                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    totalPrice = totalPrice * 0.95;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
