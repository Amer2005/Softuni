using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public Tire(double pressure, double age)
        {
            Age = age;
            Pressure = pressure;
        }

        public double Age { get; set; }

        public double Pressure { get; set; }
    }
}
