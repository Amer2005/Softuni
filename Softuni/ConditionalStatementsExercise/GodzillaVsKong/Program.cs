using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            int actors = int.Parse(Console.ReadLine());

            double pricePerActor = double.Parse(Console.ReadLine());

            double moneyNeeded = 0;

            moneyNeeded += budget * 0.1;

            if (actors <= 150)
            {
                moneyNeeded += pricePerActor * actors;
            }
            else
            {
                moneyNeeded += pricePerActor * actors * 0.9;
            }

            if(moneyNeeded <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - moneyNeeded:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded - budget:f2} leva more.");
            }
        }
    }
}
