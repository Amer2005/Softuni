namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Opel";
        private const string Model = "Astra";
        private const double FuelConsumption = 5;
        private const double FuelCapacity = 300;


        [Test]
        public void ConstructorShouldReturnCorrectValue()
        {
            Car car = new Car(Make, Model, FuelConsumption, FuelCapacity);

            Assert.That(Make, Is.EqualTo(car.Make));
            Assert.That(Model, Is.EqualTo(car.Model));
            Assert.That(FuelConsumption, Is.EqualTo(car.FuelConsumption));
            Assert.That(FuelCapacity, Is.EqualTo(car.FuelCapacity));
            Assert.That(0, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void MakeShouldThrowExceptionIfNull()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Car car = new Car(null, Model, FuelConsumption, FuelCapacity);
            });

            Assert.AreEqual("Make cannot be null or empty!", ex.Message);
        }

        [Test]
        public void ModelShouldThrowExceptionIfNull()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Car car = new Car(Make, null, FuelConsumption, FuelCapacity);
            });

            Assert.AreEqual("Model cannot be null or empty!", ex.Message);
        }

        [Test]
        public void FuelConsumptionShouldNotBeZeroOrNegative()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Car car = new Car(Make, Model, -4, FuelCapacity);
            });

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", ex.Message);
        }

        [Test]
        public void FuelCapacityShouldNotBeZeroOrNegative()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Car car = new Car(Make, Model, FuelConsumption, -5);
            });

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", ex.Message);
        }

        [Test]
        public void RefuelShouldRefuelTheCarCorrectly()
        {
            Car car = new Car(Make, Model, FuelConsumption, FuelCapacity);

            double refuelAmount = 100;

            car.Refuel(refuelAmount);
            car.Refuel(refuelAmount);

            Assert.That(car.FuelAmount, Is.EqualTo(refuelAmount * 2));
        }

        [Test]
        public void RefuelShouldRefuelTheCarUntilTankIsFull()
        {
            Car car = new Car(Make, Model, FuelConsumption, FuelCapacity);

            double refuelAmount = FuelCapacity + 50;

            car.Refuel(refuelAmount);

            Assert.That(car.FuelAmount, Is.EqualTo(FuelCapacity));
        }

        [Test]
        public void RefuelShouldThrowExceptionIfFuelIsNegative()
        {
            Car car = new Car(Make, Model, FuelConsumption, FuelCapacity);

            double refuelAmount = -50;

            var ex = Assert.Catch<ArgumentException>(() =>
            {
                car.Refuel(refuelAmount);
            });

            Assert.AreEqual("Fuel amount cannot be zero or negative!", ex.Message);
        }

        [Test]
        public void DriveShouldDiveCorrectly()
        {
            Car car = new Car(Make, Model, FuelConsumption, FuelCapacity);

            double fuel = 150;

            car.Refuel(fuel);

            double distance = 10;

            car.Drive(distance);

            double expectedFuel = fuel -(distance / 100) * FuelConsumption;

            Assert.That(expectedFuel, Is.EqualTo(car.FuelAmount));    
        }

        [Test]
        public void DriveShouldThrowExceptionIfNotEnoughFuel()
        {
            Car car = new Car(Make, Model, FuelConsumption, FuelCapacity);

            double fuel = 150;

            car.Refuel(fuel);

            double distance = 10000;

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });

            Assert.AreEqual("You don't have enough fuel to drive!", ex.Message);
        }
    }
}