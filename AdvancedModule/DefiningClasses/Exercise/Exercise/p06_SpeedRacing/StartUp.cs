using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] splittedArgs = Console.ReadLine().Split(' ');

                string model = splittedArgs[0];

                double fuelAmount = double.Parse(splittedArgs[1]);

                double fuelConsumptionForPerKm = double.Parse(splittedArgs[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionForPerKm));
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedArgs = input.Split(' ');

                string model = splittedArgs[1];

                double distance = double.Parse(splittedArgs[2]);

                Car currentCar = cars.FirstOrDefault(c => c.Model == model);

                if (!currentCar.Drive(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}
