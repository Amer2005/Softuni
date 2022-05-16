using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    Console.WriteLine(String.Join("\n", customers.ToArray()));

                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(input);
                }

            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
