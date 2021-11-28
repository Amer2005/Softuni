using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double gpuPrice = 250;

            double cpuPrice;

            double ramPrice;

            double budget = double.Parse(Console.ReadLine());
            int gpus = int.Parse(Console.ReadLine());
            int cpus = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            cpuPrice = gpus * gpuPrice * 0.35;
            ramPrice = gpus * gpuPrice * 0.1;

            double price = gpus * gpuPrice + cpus * cpuPrice + ram * ramPrice;

            if(gpus > cpus)
            {
                price *= 0.85;
            }

            if(price <= budget)
            {
                Console.WriteLine($"You have {budget - price:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva more!");
            }
        }
    }
}
