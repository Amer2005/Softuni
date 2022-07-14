using System;

namespace p01_Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]));

            inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle truck = new Truck(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Vehicle vehicle;

                if (inputArgs[1] == "Car")
                {
                    vehicle = car;
                }
                else
                {
                    vehicle = truck;
                }

                if (inputArgs[0] == "Drive")
                {
                    Console.WriteLine(vehicle.Drive(double.Parse(inputArgs[2])));
                }
                else
                {
                    vehicle.Refuel(double.Parse(inputArgs[2]));
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
