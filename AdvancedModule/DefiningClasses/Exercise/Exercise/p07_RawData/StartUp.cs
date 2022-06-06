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

                Engine carEngine = new Engine(double.Parse(splittedArgs[1]), double.Parse(splittedArgs[2]));
                Cargo carCargo = new Cargo(double.Parse(splittedArgs[3]), splittedArgs[4]);

                Tire[] carTires = new Tire[] { new Tire(double.Parse(splittedArgs[5]), double.Parse(splittedArgs[6])),
                new Tire(double.Parse(splittedArgs[7]), double.Parse(splittedArgs[8])),
                new Tire(double.Parse(splittedArgs[9]), double.Parse(splittedArgs[10])),
                new Tire(double.Parse(splittedArgs[11]), double.Parse(splittedArgs[12]))};

                Car currentCar = new Car(model, carCargo, carEngine, carTires);

                cars.Add(currentCar);
            }

            string searchCargoType = Console.ReadLine();

            if (searchCargoType == "fragile")
            {
                Console.WriteLine(String.Join(Environment.NewLine, cars
                .Where(c => c.Cargo.Type == searchCargoType)
                .Where(c => c.Tires.Any(c => c.Pressure < 1))
                .Select(c => c.Model)));
            }
            else
            {
                Console.WriteLine(String.Join(Environment.NewLine, cars
                .Where(c => c.Cargo.Type == searchCargoType)
                .Where(c => c.Engine.Power > 250)
                .Select(c => c.Model)));
            }
        }
    }
}
