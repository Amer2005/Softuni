using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
        }
    }

    class Car
    {

        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

    }
}
