using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; }

        public string Color { get; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
