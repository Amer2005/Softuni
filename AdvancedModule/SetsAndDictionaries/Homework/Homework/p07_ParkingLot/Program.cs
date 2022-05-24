using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            HashSet<string> cars = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string action = inputArgs[0];
                string car = inputArgs[1];

                if (action == "IN" && !cars.Contains(car))
                {
                    cars.Add(car);
                }
                else if (action == "OUT" && cars.Contains(car))
                {
                    cars.Remove(car);
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");

                return;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
