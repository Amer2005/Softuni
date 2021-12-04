using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {

            string city = Console.ReadLine();

            double sum = double.Parse(Console.ReadLine());

            while(true)
            {
                double sumNow = 0;

                while(sumNow < sum)
                {
                    double savings = double.Parse(Console.ReadLine());

                    sumNow += savings;
                }

                Console.WriteLine($"Going to {city}!");

                city = Console.ReadLine();

                if(city == "End")
                {
                    break;
                }

                sum = double.Parse(Console.ReadLine());
            }
        }
    }
}
