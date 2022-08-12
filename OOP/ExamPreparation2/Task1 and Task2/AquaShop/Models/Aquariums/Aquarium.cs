using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        private Aquarium()
        {
            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        protected Aquarium(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity 
        { 
            get => capacity; 
            private set => capacity = value; 
        }

        public int Comfort => Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations 
        { 
            get => decorations; 
            private set => decorations = value; 
        }

        public ICollection<IFish> Fish 
        { 
            get => fish;
            private set => fish = value; 
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{this.Name} ({this.GetType().Name}):" + Environment.NewLine);
            if (Fish.Count == 0)
            {
                result.Append($"Fish: none" + Environment.NewLine);
            }
            else
            {
                result.Append($"Fish: {string.Join(", ", Fish.Select(x => x.Name))}" + Environment.NewLine);
            }

            result.Append($"Decorations: {Decorations.Count}" + Environment.NewLine);
            result.Append($"Comfort: {this.Comfort}");

            return result.ToString().TrimEnd();
        }
    }
}
