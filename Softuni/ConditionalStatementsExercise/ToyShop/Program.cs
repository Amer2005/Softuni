using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());

            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int tedyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double totalPrice = puzzles * 2.6;
            totalPrice += dolls * 3;
            totalPrice += tedyBears * 4.1;
            totalPrice += minions * 8.2;
            totalPrice += trucks * 2;

            int amountOfToys = puzzles + dolls + tedyBears + minions + trucks;

            if(amountOfToys >= 50)
            {
                totalPrice = totalPrice * 0.75;
            }

            totalPrice = totalPrice * 0.9;

            if (totalPrice >= tripPrice)
            {
                Console.WriteLine($"Yes! {totalPrice - tripPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripPrice - totalPrice:f2} lv needed.");
            }
        }
    }
}
