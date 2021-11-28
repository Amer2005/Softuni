using System;

namespace IfStatementsAdvancedExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticket = Console.ReadLine();

            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            double price = 0;

            if(ticket == "Premiere")
            {
                price = 12;
            }
            else if(ticket == "Normal")
            {
                price = 7.5;
            }
            else if(ticket == "Discount")
            {
                price = 5;
            }

            Console.WriteLine($"{row * col * price:f2} leva");
        }
    }
}
