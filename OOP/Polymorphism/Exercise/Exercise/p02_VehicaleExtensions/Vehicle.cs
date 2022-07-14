using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicales
{
    public abstract class Vehicle
    {
        private double fuelQuantity = 0;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;

            if (this.TankCapacity < fuelQuantity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > tankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {value - fuelQuantity} fuel in the tank");
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get => fuelConsumption + FuelConsumptionAddition;
            protected set
            {
                fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get => tankCapacity;
            protected set => tankCapacity = value;
        }

        protected virtual double FuelConsumptionAddition => 0;

        public string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                return $"{GetType().Name} travelled {distance} km";
            }
            {
                return $"{GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
