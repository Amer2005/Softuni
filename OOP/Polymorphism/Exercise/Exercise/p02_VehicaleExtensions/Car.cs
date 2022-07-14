using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicales
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionAddition => 0.9;
    }
}
