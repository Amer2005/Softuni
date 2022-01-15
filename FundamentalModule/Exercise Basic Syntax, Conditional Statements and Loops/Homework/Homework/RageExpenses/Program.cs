using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headsetExpenses = headsetPrice * (Math.Floor((double)gamesLost / 2));
            double mouseExpenses = mousePrice * (Math.Floor((double)gamesLost / 3));
            double keyboardExpenses = keyboardPrice * (Math.Floor((double)gamesLost / 6));
            double displayExpenses = displayPrice * (Math.Floor((double)gamesLost / 12));

            double rageExpenses = headsetExpenses + mouseExpenses + keyboardExpenses + displayExpenses;

            Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");

        }
    }
}
