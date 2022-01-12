using System;

namespace ChristmasPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int paper = int.Parse(Console.ReadLine());
            int silk = int.Parse(Console.ReadLine());
            double glue = double.Parse(Console.ReadLine());

            int sale = int.Parse(Console.ReadLine());

            double paperPrice = paper * 5.8;
            double silkPrice = silk * 7.2;
            double gluePrice = glue * 1.2;

            double totalPrice = (paperPrice + silkPrice + gluePrice) * (100 - sale) / 100;

            Console.WriteLine($"{totalPrice:f3}");
        }
    }
}
