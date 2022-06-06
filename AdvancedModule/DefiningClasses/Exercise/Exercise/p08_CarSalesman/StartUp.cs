using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineCount; i++)
            {
                string input = Console.ReadLine();

                engines.Add(new Engine(input));
            }

            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string input = Console.ReadLine();

                cars.Add(new Car(input, engines));
            }

            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}

/*
2
V8-101 220 50
V4-33 140 28 B
3
FordFocus V4-33 1300 Silver
FordMustang V8-101
VolkswagenGolf V4-33 Orange

*/