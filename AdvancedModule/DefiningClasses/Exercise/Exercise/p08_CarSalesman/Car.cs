using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string stringProperties, List<Engine> engines)
        {
            string[] splittedArgs = stringProperties.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Weight = -1;
            Color = "n/a";

            Model = splittedArgs[0];
            Engine = engines.First(e => e.Model == splittedArgs[1]);

            if (splittedArgs.Length == 4)
            {
                Weight = int.Parse(splittedArgs[2]);
                Color = splittedArgs[3];
            }
            else if (splittedArgs.Length == 3)
            {
                int weight;

                if (int.TryParse(splittedArgs[2], out weight))
                {
                    Weight = weight;
                }
                else
                {
                    Color = splittedArgs[2];
                }
            }
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(Model + ":");
            result.AppendLine($"  {Engine.Model}:");
            result.AppendLine($"    Power: {Engine.Power}");
            result.AppendLine($"    Displacement: " + ((Engine.Displacement == -1) ? "n/a" : Engine.Displacement.ToString()));
            result.AppendLine($"    Efficiency: {Engine.Efficiency}");
            result.AppendLine($"  Weight: " + ((Weight == -1) ? "n/a" : Weight.ToString()));
            result.Append($"  Color: {Color}");
            return result.ToString();
        }
    }
}
