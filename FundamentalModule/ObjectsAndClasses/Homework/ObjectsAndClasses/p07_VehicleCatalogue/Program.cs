using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_VehicleCatalogue
{
    public class Car : IComparable<Car>
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public int CompareTo(Car other)
        {
            if (this.Brand.CompareTo(other.Brand) == 0)
            {
                return 1;
            }

            return this.Brand.CompareTo(other.Brand);
        }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }

    public class Truck : IComparable<Truck>
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public int CompareTo(Truck other)
        {
            if (this.Brand.CompareTo(other.Brand) == 0)
            {
                return 1;
            }

            return this.Brand.CompareTo(other.Brand);
        }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    public class Catalog
    {
        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            Cars = new List<Car>();

            Trucks = new List<Truck>();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Cars:");

            result.AppendLine(String.Join("\n", Cars));

            result.AppendLine("Trucks:");

            result.AppendLine(String.Join("\n", Trucks));

            return result.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split('/');

                string vehicleType = inputs[0];
                string brand = inputs[1];
                string model = inputs[2];

                if (vehicleType == "Car")
                {
                    int horsePower = int.Parse(inputs[3]);

                    catalog.Cars.Add(new Car(brand, model, horsePower));
                }
                else
                {
                    int weight = int.Parse(inputs[3]);

                    catalog.Trucks.Add(new Truck(brand, model, weight));
                }
            }

            catalog.Cars.Sort();
            catalog.Trucks.Sort();

            Console.WriteLine(catalog);
        }
    }
}
