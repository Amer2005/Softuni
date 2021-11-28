using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] coins = { 2, 1, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };

            decimal money = decimal.Parse(Console.ReadLine());

            int numberOfCoins = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                while(money - coins[i] >= 0)
                {
                    numberOfCoins++;

                    money -= coins[i];
                }
            }

            Console.WriteLine(numberOfCoins);
        }
    }
}
