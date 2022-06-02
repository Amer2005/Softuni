using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(1, 0.5),
                new Tire(1, 2.3)
            };

            var engine = new Engine(560, 6300);

            var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            Console.WriteLine(car.WhoAmI());
        }
    }

    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
            Engine = new Engine();
            Tires = new Tire[0];
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
                Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity >= distance * FuelConsumption)
            {
                FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}";
        }
    }

    public class Engine
    {
        public Engine()
        {

        }

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            this.cubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }

        public double cubicCapacity { get; set; }
    }

    public class Tire
    {
        public Tire()
        {

        }

        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }

        public int Year { get; set; }

        public double Pressure { get; set; }
    }
}
