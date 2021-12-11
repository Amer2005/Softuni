using System;

namespace EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int clients = int.Parse(Console.ReadLine());

            double totalProfit = 0;

            for (int i = 0; i < clients; i++)
            {
                string product = Console.ReadLine();

                double price = 0;

                int numOfItems = 0;

                while(product != "Finish")
                {
                    numOfItems++;
                    if (product == "basket")
                    {
                        price += 1.5;
                    }
                    else if(product == "wreath")
                    {
                        price += 3.8;
                    }
                    else
                    {
                        price += 7;
                    }

                    product = Console.ReadLine();
                }

                if(numOfItems % 2 == 0)
                {
                    price = price * 0.8;
                }

                Console.WriteLine($"You purchased {numOfItems} items for {price:f2} leva.") ;

                totalProfit += price;
            }

            Console.WriteLine($"Average bill per client is: {totalProfit / clients:f2} leva.");
        }
    }
}
