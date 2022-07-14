using System;
using System.Collections.Generic;
using System.Text;

namespace p01_Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        { 
            get => fuelQuantity; 
            protected set => fuelQuantity = value; 
        }
        
        public double FuelConsumption 
        { 
            get => fuelConsumption;
            protected set
            {
                fuelConsumption = value + FuelConsumptionModifier;
            }
        }


        protected virtual double FuelConsumptionModifier => 1;

        public string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
