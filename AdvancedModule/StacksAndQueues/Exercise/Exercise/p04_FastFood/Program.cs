using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfFoodLeft = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                int orderNow = orders.Peek();

                if(orderNow <= amountOfFoodLeft)
                {
                    amountOfFoodLeft -= orderNow;

                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", orders)}");
            }
        }
    }
}
