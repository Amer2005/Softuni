using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public List<Drone> Drones { get; set; }

        public int Count => this.Drones.Count(x => x.Available);

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public string AddDrone(Drone drone)
        {
            if (this.Drones.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }

            if (drone == null)
            {
                return "Invalid drone.";
            }

            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }

            if (drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }

            Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (!this.Drones.Any(x => x.Name == name))
            {
                return false;
            }

            Drones = Drones.Where(x => x.Name != name).ToList();

            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int dronesFromBrand = this.Drones.Count(x => x.Brand == brand);

            this.Drones = this.Drones.Where(x => x.Brand != brand).ToList();

            return dronesFromBrand;
        }

        public Drone FlyDrone(string name)
        {
            if (!this.Drones.Any(x => x.Name == name))
            {
                return null;
            }

            Drone drone = this.Drones.FirstOrDefault(x => x.Name == name);

            drone.Available = false;

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToFly = this.Drones.Where(x => x.Range >= range).ToList();

            for (int i = 0; i < dronesToFly.Count; i++)
            {
                dronesToFly[i].Available = false;
            }

            return dronesToFly;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"Drones available at {this.Name}:" + Environment.NewLine);
            result.Append($"{string.Join(Environment.NewLine, Drones.Where(x => x.Available))}");

            return result.ToString();
        }
    }
}
