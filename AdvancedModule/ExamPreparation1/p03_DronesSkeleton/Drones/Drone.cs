using System.Text;
using System;
namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Available = true;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public int Range { get; set; }

        public bool Available { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"Drone: {Name}" + Environment.NewLine);
            result.Append($"Manufactured by: {Brand}" + Environment.NewLine);
            result.Append($"Range: {Range} kilometers");

            return result.ToString();
        }
    }
}
