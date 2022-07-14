using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicales
{
    public class Truck : Vehicle
    {
        private const double TruckFuelLoss = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionAddition => 1.6;

        public override void Refuel(double liters)
        {
            try
            {
                base.Refuel(liters * (1 - TruckFuelLoss));
            }
            catch (ArgumentException ae)
            {
                if (liters <= 0)
                {
                    throw new ArgumentException(ae.Message);
                }

                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
        }
    }
}
