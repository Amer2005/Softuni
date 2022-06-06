using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Cargo cargo, Engine engine, Tire[] tires)
        {
            Model = model;
            Cargo = cargo;
            Engine = engine;

            if (tires.Length != 4)
            {
                Tires = new Tire[4];
            }
            else
            {
                Tires = tires;
            }
        }

        public string Model { get; set; }

        public Cargo Cargo { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }
    }
}
