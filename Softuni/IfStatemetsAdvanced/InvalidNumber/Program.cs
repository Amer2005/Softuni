using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            if ((number < 100 || number > 200) && number != 0)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
