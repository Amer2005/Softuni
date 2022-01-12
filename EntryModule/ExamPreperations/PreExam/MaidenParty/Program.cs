using System;

namespace MaidenParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double partyPrice = double.Parse(Console.ReadLine());
            int loveLetters = int.Parse(Console.ReadLine());
            int waxRoses = int.Parse(Console.ReadLine());
            int keyChains = int.Parse(Console.ReadLine());
            int caricatures = int.Parse(Console.ReadLine());
            int luckPresents = int.Parse(Console.ReadLine());

            int numOfItems = loveLetters + waxRoses + keyChains + caricatures + luckPresents;

            double priceOfItems = loveLetters * 0.6 + waxRoses * 7.2 + keyChains * 3.6 + caricatures * 18.2 + luckPresents * 22;

            if(numOfItems >= 25)
            {
                priceOfItems = priceOfItems * (1 - 0.35);
            }

            priceOfItems = priceOfItems * 0.9;

            if (priceOfItems >= partyPrice)
            {
                Console.WriteLine($"Yes! {priceOfItems - partyPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {partyPrice - priceOfItems:f2} lv needed.");
            }
        }
    }
}
