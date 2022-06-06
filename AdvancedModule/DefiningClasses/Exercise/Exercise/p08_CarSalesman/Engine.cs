using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string stringProperties)
        {
            string[] splittedArgs = stringProperties.Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

            Displacement = -1;
            Efficiency = "n/a";

            Model = splittedArgs[0];
            Power = int.Parse(splittedArgs[1]);

            if (splittedArgs.Length == 4)
            {
                Displacement = int.Parse(splittedArgs[2]);
                Efficiency = splittedArgs[3];
            }
            else if (splittedArgs.Length == 3)
            {
                int displacement;

                if (int.TryParse(splittedArgs[2], out displacement))
                {
                    Displacement = displacement;
                }
                else
                {
                    Efficiency = splittedArgs[2];
                }
            }
        }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }
    }
}
