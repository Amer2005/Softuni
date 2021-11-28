using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            string action = Console.ReadLine();

            int spendingSpree = 0;

            int days = 0;

            while(true)
            {
                days++;

                double moneyChanged = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    money -= moneyChanged;

                    if (money < 0)
                    {
                        money = 0;
                    }

                    spendingSpree++;
                }
                else
                {
                    money += moneyChanged;
                    spendingSpree = 0;
                }

                if(spendingSpree >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);

                    return;
                }

                if(money >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {days} days.");

                    return;
                }

                action = Console.ReadLine();
            }
        }
    }
}
