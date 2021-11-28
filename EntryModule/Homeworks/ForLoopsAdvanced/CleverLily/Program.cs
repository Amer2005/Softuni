using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            double price = double.Parse(Console.ReadLine());

            double priceForToy = double.Parse(Console.ReadLine());

            double totalMoney = 0;

            for (int i = 2; i <= age; i += 2)
            {
                totalMoney += i * 5 - 1;
            }

            totalMoney += (age / 2 + age % 2) * priceForToy;

            if (totalMoney >= price)
            {
                Console.WriteLine($"Yes! {totalMoney - price :f2}");
            }
            else
            {
                Console.WriteLine($"No! {price - totalMoney:f2}");
            }
        }
    }
}
