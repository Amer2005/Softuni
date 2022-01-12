using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatrePromotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double price = 0;

            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");

                return;
            }

            if (day == "Weekday")
            {
                if (age <= 18)
                {
                    price = 12;
                }
                else if (age <= 64)
                {
                    price = 18;
                }
                else
                {
                    price = 12;
                }
            }
            else if (day == "Weekend")
            {
                if (age <= 18)
                {
                    price = 15;
                }
                else if (age <= 64)
                {
                    price = 20;
                }
                else
                {
                    price = 15;
                }
            }
            else
            {
                if (age <= 18)
                {
                    price = 5;
                }
                else if (age <= 64)
                {
                    price = 12;
                }
                else
                {
                    price = 10;
                }
            }

            Console.WriteLine($"{price}$");
        }
    }
}
