namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AquariumsTests
    {
        [Test]
        [TestCase("Aqua", 4)]
        [TestCase("asd", 6)]
        [TestCase("34", 2)]
        public void ConstructorShouldWorkCorrectly(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NameCannotBeNullOrEmpty(string name)
        {
            var ex = Assert.Catch<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 3);
            });

            Assert.AreEqual("Invalid aquarium name! (Parameter 'value')", ex.Message);
        }

        [Test]
        [TestCase(-3)]
        [TestCase(-1)]
        public void CapacityCannotBeNegative(int capacity)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Asd", capacity);
            });

            Assert.AreEqual("Invalid aquarium capacity!", ex.Message);
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            string aquariumName = "Asd";
            
            Aquarium aquarium = new Aquarium(aquariumName, 100);

            Fish[] fishes =
            {
                new Fish("Gorge"),
                new Fish("Sarah"),
                new Fish("Bobo")
            };

            foreach (var fish in fishes)
            {
                aquarium.Add(fish);
            }

            Assert.AreEqual(fishes.Length, aquarium.Count);
            Assert.AreEqual(GenerateFakeReport(fishes, aquariumName), aquarium.Report());
        }

        [Test]
        public void AddShouldThrowExceptionIfAquariumIsFull()
        {
            string aquariumName = "Asd";

            Aquarium aquarium = new Aquarium(aquariumName, 3);

            Fish[] fishes =
            {
                new Fish("Gorge"),
                new Fish("Sarah"),
                new Fish("Bobo")
            };

            foreach (var fish in fishes)
            {
                aquarium.Add(fish);
            }

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Boom"));
            });

            Assert.AreEqual("Aquarium is full!", ex.Message);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void RemoveShouldRemoveCorrectly(int fishToRemoveIndex)
        {
            string aquariumName = "Asd";

            Aquarium aquarium = new Aquarium(aquariumName, 100);

            List<Fish> fishes = new List<Fish>
            {
                new Fish("Gorge"),
                new Fish("Sarah"),
                new Fish("Bobo")
            };

            foreach (var fish in fishes)
            {
                aquarium.Add(fish);
            }

            string fishToRemoveName = fishes[fishToRemoveIndex].Name;

            Fish fishToRemove = fishes.FirstOrDefault(x => x.Name == fishToRemoveName);

            fishes.Remove(fishToRemove);

            aquarium.RemoveFish(fishToRemoveName);

            Assert.AreEqual(fishes.Count, aquarium.Count);
            Assert.AreEqual(GenerateFakeReport(fishes.ToArray(), aquariumName), aquarium.Report());
        }

        [Test]
        public void RemoveShouldThrowExceptionIfFishNotFound()
        {
            string aquariumName = "Asd";

            Aquarium aquarium = new Aquarium(aquariumName, 100);

            Fish[] fishes =
            {
                new Fish("Gorge"),
                new Fish("Sarah"),
                new Fish("Bobo")
            };

            foreach (var fish in fishes)
            {
                aquarium.Add(fish);
            }

            string fishName = "None";

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fishName);
            });

            Assert.AreEqual($"Fish with the name {fishName} doesn't exist!", ex.Message);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void SellFishShouldWorkCorrectly(int fishToSellIndex)
        {
            string aquariumName = "Asd";

            Aquarium aquarium = new Aquarium(aquariumName, 100);

            List<Fish> fishes = new List<Fish>
            {
                new Fish("Gorge"),
                new Fish("Sarah"),
                new Fish("Bobo")
            };

            foreach (var fish in fishes)
            {
                aquarium.Add(fish);
            }

            string fishToSellName = fishes[fishToSellIndex].Name;

            Fish soldFish = aquarium.SellFish(fishToSellName);

            Assert.IsFalse(soldFish.Available);
            Assert.AreEqual(soldFish.Name, fishToSellName);
        }

        [Test]
        public void SellFishShouldThrowExceptionIfFishNotFound()
        {
            string aquariumName = "Asd";

            Aquarium aquarium = new Aquarium(aquariumName, 100);

            Fish[] fishes =
            {
                new Fish("Gorge"),
                new Fish("Sarah"),
                new Fish("Bobo")
            };

            foreach (var fish in fishes)
            {
                aquarium.Add(fish);
            }

            string fishName = "None";

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                aquarium.SellFish(fishName);
            });

            Assert.AreEqual($"Fish with the name {fishName} doesn't exist!", ex.Message);
        }

        private string GenerateFakeReport(Fish[] fishes, string aquariumName)
        {
            string fishNames = string.Join(", ", fishes.Select(f => f.Name));
            string report = $"Fish available at {aquariumName}: {fishNames}";

            return report;
        }
    }
}
