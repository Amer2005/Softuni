using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            long totalSpices = 0;

            int days = 0;

            while (yield >= 100)
            {
                days++;
                totalSpices += yield;

                yield -= 10;
                totalSpices -= 26;

                if (totalSpices < 0)
                {
                    totalSpices = 0;
                }
            }

            totalSpices -= 26;

            if (totalSpices < 0)
            {
                totalSpices = 0;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpices);
        }
    }
}
