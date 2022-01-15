using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double orderPrice = days * capsulePrice * capsuleCount;

                totalPrice += orderPrice;

                Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
