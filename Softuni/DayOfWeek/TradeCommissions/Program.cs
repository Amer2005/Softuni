using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double commission = 0;

            if(city == "Sofia")
            {
                if (amount < 0)
                {
                    Console.WriteLine("error");

                    return;
                }
                else if (amount <= 500)
                {
                    commission = 5;
                }
                else if (amount <= 1000)
                {
                    commission = 7;
                }
                else if (amount <= 10000)
                {
                    commission = 8;
                }
                else
                {
                    commission = 12;
                }
            }
            else if (city == "Varna")
            {
                if (amount < 0)
                {
                    Console.WriteLine("error");

                    return;
                }
                else if (amount <= 500)
                {
                    commission = 4.5;
                }
                else if (amount <= 1000)
                {
                    commission = 7.5;
                }
                else if (amount <= 10000)
                {
                    commission = 10;
                }
                else
                {
                    commission = 13;
                }
            }
            else if (city == "Plovdiv")
            {
                if (amount < 0)
                {
                    Console.WriteLine("error");

                    return;
                }
                else if (amount <= 500)
                {
                    commission = 5.5;
                }
                else if (amount <= 1000)
                {
                    commission = 8;
                }
                else if (amount <= 10000)
                {
                    commission = 12;
                }
                else
                {
                    commission = 14.5;
                }
            }
            else
            {
                Console.WriteLine("error");

                return;
            }

            Console.WriteLine($"{commission * amount / 100:f2}");
        }
    }
}
