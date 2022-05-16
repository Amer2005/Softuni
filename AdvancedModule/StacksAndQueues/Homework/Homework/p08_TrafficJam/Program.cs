using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsPassedPerGreen = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input;

            int numberOfCarsPassed = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < numberOfCarsPassedPerGreen; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine("{0} passed!",cars.Dequeue());

                        numberOfCarsPassed++;
                    }
                }
            }

            Console.WriteLine($"{numberOfCarsPassed} cars passed the crossroads.");
        }
    }
}
