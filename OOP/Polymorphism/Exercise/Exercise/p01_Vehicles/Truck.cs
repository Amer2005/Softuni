using System;
using System.Collections.Generic;
using System.Text;

namespace p01_Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckFuelLoss = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        protected override double FuelConsumptionModifier => 1.6;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * (1 - TruckFuelLoss));
        }
    }
}
