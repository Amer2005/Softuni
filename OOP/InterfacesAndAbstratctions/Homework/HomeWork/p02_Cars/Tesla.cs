using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery) 
            : base(model, color)
        {
            Battery = battery;
        }

        public int Battery { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{base.ToString()} with {this.Battery} batteries");
            result.AppendLine($"{this.Start()}");
            result.AppendLine($"{this.Stop()}");

            return result.ToString().TrimEnd();
        }
    }
}
