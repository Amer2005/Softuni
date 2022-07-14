using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicales
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            IsBusEmpty = true;
        }

        public bool IsBusEmpty { get; set; }

        protected override double FuelConsumptionAddition => IsBusEmpty ? 0 : 1.4;
    }
}
