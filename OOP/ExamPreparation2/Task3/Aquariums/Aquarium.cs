namespace Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Aquarium
    {
        private string name;
        private int capacity;
        private List<Fish> fish;

        //done
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public string Name
        {
            get
            {
                //done
                return this.name;
            }

            private set
            {
                //done
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid aquarium name!");
                }

                //done
                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                //done
                return this.capacity;
            }

            private set
            {
                //done
                if (value < 0)
                {
                    throw new ArgumentException("Invalid aquarium capacity!");
                }

                //done
                this.capacity = value;
            }
        }

        //done
        public int Count => this.fish.Count;

        
        public void Add(Fish fish)
        {
            if (this.fish.Count == this.capacity)
            {
                //done
                throw new InvalidOperationException("Aquarium is full!");
            }

            //done
            this.fish.Add(fish);
        }

        public void RemoveFish(string name)
        {
            Fish fishToRemove = this.fish.FirstOrDefault(x => x.Name == name);

            if (fishToRemove == null)
            {
                //done
                throw new InvalidOperationException($"Fish with the name {name} doesn't exist!");
            }

            //done
            this.fish.Remove(fishToRemove);
        }

        public Fish SellFish(string name)
        {
            Fish requestedFish = this.fish.FirstOrDefault(x => x.Name == name);

            if (requestedFish == null)
            {
                //done
                throw new InvalidOperationException($"Fish with the name {name} doesn't exist!");
            }

            //done
            requestedFish.Available = false;

            return requestedFish;
        }

        public string Report()
        {
            string fishNames = string.Join(", ", this.fish.Select(f => f.Name));
            string report = $"Fish available at {this.Name}: {fishNames}";

            return report;
        }
    }
}
