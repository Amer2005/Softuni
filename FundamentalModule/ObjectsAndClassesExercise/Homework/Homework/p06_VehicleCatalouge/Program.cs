using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_VehicleCatalouge
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            //              Type: {typeOfVehicle}
            //              Model: { modelOfVehicle}
            //              Color: { colorOfVehicle}
            //              Horsepower: { horsepowerOfVehicle}


            string vehicleType = Type == "car" ? "Car" : "Truck";

            result.AppendLine($"Type: {vehicleType}");
            result.AppendLine($"Model: {Model}");
            result.AppendLine($"Color: {Color}");
            result.Append($"Horsepower: {HorsePower}");

            return result.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();   

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] carArgs = input.Split(' ');

                string vehicleType = carArgs[0];
                string model = carArgs[1];
                string color = carArgs[2];
                int horsePower = int.Parse(carArgs[3]);

                vehicles.Add(new Vehicle(vehicleType, model, color, horsePower));
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                string model = input;

                Vehicle vehicle = vehicles.FirstOrDefault(x => x.Model == model);

                if (vehicle == null)
                {
                    continue;
                }

                Console.WriteLine(vehicle);
            }

            double carAvarageHorsePower = 0;
            double truckAvarageHorsePower = 0;

            if (vehicles.Any(x => x.Type == "car"))
            {
                carAvarageHorsePower = vehicles.Where(x => x.Type == "car").Average(x => x.HorsePower);
            }

            if (vehicles.Any(x => x.Type == "truck"))
            {
                truckAvarageHorsePower = vehicles.Where(x => x.Type == "truck").Average(x => x.HorsePower);
            }

            Console.WriteLine($"Cars have average horsepower of: {carAvarageHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAvarageHorsePower:f2}.");
        }
    }
}
