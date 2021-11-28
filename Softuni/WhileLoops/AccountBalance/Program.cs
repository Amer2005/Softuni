using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;

            string input = Console.ReadLine();

            while(input != "NoMoreMoney")
            {
                double money = double.Parse(input);

                if(money < 0)
                {
                    Console.WriteLine("Invalid operation!");

                    break;
                }

                total += money;

                Console.WriteLine($"Increase: {money:f2}");

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
