using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10_Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenTimer = int.Parse(Console.ReadLine());
            int freeTime = int.Parse(Console.ReadLine());

            string input;

            Queue<string> cars = new Queue<string>();

            int carsPassed = 0;

            while((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int greenTimerLeft = greenTimer;

                    string carNow = "";

                    bool skip = false;

                    while(greenTimerLeft > 0)
                    {
                        if (cars.Count == 0)
                        {
                            skip = true;

                            break;
                        }

                        carNow = cars.Dequeue();

                        carsPassed++;

                        greenTimerLeft -= carNow.Length;
                    }

                    if (-greenTimerLeft > freeTime && skip == false)
                    {
                        greenTimerLeft += carNow.Length;

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{carNow} was hit at {carNow[freeTime + greenTimerLeft]}.");

                        return;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
