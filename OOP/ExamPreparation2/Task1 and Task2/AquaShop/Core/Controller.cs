using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (!decorations.Models.Any(x => x.GetType().Name == decorationType))
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IDecoration decoration = decorations.FindByType(decorationType);

            decorations.Remove(decoration);

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.AddDecoration(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium,
                                    decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if(fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if((aquarium is FreshwaterAquarium && fish is FreshwaterFish)
            || (aquarium is SaltwaterAquarium && fish is SaltwaterFish))
            {
                aquarium.AddFish(fish);

                return String.Format(OutputMessages.EntityAddedToAquarium,
                                    fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }

        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();

            return String.Format(OutputMessages.FishFed,
                                    aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal aquariumValue = aquarium.Fish.Sum(x => x.Price);
            aquariumValue += aquarium.Decorations.Sum(x => x.Price);

            return String.Format(OutputMessages.AquariumValue,
                aquariumName, aquariumValue);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                report.Append(aquarium.GetInfo() + Environment.NewLine);
            }

            return report.ToString().TrimEnd();
        }
    }
}
