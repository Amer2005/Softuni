using System;

namespace Vehicales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = null;

            car = new Car(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
            
            inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle truck = new Truck(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));

            inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle bus = new Bus(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {

                inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Vehicle vehicle;

                if (inputArgs[1] == "Car")
                {
                    vehicle = car;
                }
                else if (inputArgs[1] == "Truck")
                {
                    vehicle = truck;
                }
                else
                {
                    vehicle = bus;
                }

                if (vehicle is Bus)
                {
                    Bus busNow = vehicle as Bus;

                    busNow.IsBusEmpty = inputArgs[0] != "Drive";
                }

                if (inputArgs[0].StartsWith("Drive"))
                {
                    Console.WriteLine(vehicle.Drive(double.Parse(inputArgs[2])));
                }
                else
                {
                    vehicle.Refuel(double.Parse(inputArgs[2]));
                }


                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
