using NUnit.Framework;
using System;
using System.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            [TestCase("Frees", 3)]
            [TestCase("Gragas", 5)]
            public void GarageConstructorShouldWorkProperly(string name, int mechanicsAvailable)
            {
                Garage garage = new Garage(name, mechanicsAvailable);

                Assert.AreEqual(name, garage.Name);
                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }
            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void GarageNameCannotBeNullOrEmpty(string name)
            {
                var ex = Assert.Catch<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 3);
                });

                Assert.AreEqual("Invalid garage name. (Parameter 'value')", ex.Message);
            }

            [Test]
            [TestCase(0)]
            [TestCase(-3)]
            public void GarageCantHaveZeroOrLessMechanics(int mechanics)
            {
                var ex = Assert.Catch<ArgumentException>(() =>
                {
                    Garage garage = new Garage("Greegar", mechanics);
                });

                Assert.AreEqual("At least one mechanic must work in the garage.", ex.Message);
            }

            [Test]
            public void GarageAddCarShouldWork()
            {
                Garage garage = new Garage("Wheels", 3);

                Car[] cars = new Car[]
                {
                    new Car("Opel", 3),
                    new Car("Reno", 1),
                    new Car("Jumper", 0)
                };

                foreach (var car in cars)
                {
                    garage.AddCar(car);
                }

                Assert.AreEqual(3, garage.CarsInGarage);
                Assert.AreEqual(GenerateTestReport(cars), garage.Report());
            }

            [Test]
            public void GarageShouldNotAddMoreCarsThanMechanics()
            {
                Garage garage = new Garage("Wheels", 3);

                Car[] cars = new Car[]
                {
                    new Car("Opel", 3),
                    new Car("Reno", 1),
                    new Car("Jumper", 0)
                };

                foreach (var car in cars)
                {
                    garage.AddCar(car);
                }

                var ex = Assert.Catch<InvalidOperationException > (() =>
                {
                    garage.AddCar(new Car("Boom", 2));
                });

                Assert.AreEqual("No mechanic available.", ex.Message);
            }

            [Test]
            public void GarageShouldFixCarCorrectly()
            {
                Garage garage = new Garage("Johny's", 3);

                const string model = "Opel";

                Car correctCar = new Car(model, 0);

                garage.AddCar(new Car(model, 2));

                Car fixedCar = garage.FixCar(model);

                Assert.AreEqual(correctCar.NumberOfIssues,
                                fixedCar.NumberOfIssues);

                Assert.AreEqual(correctCar.CarModel,
                                fixedCar.CarModel);
            }

            [Test]
            [TestCase("Opel", "Astra")]
            [TestCase("Opel", "opel")]
            public void GarageFixShouldThrowExceptionIfCarNotFound(string searchModel, string model)
            {
                Garage garage = new Garage("Rees", 3);

                garage.AddCar(new Car(model, 3));

                var ex = Assert.Catch<InvalidOperationException>(() =>
                {
                    garage.FixCar(searchModel);
                });

                Assert.AreEqual($"The car {searchModel} doesn't exist.", 
                                ex.Message);
            }

            [Test]
            public void GarageShouldRemoveFixedCars()
            {
                Garage garage = new Garage("Wheels", 3);

                Car[] cars = new Car[]
                {
                    new Car("Opel", 3),
                    new Car("Reno", 0),
                    new Car("Jumper", 0)
                };

                foreach (var car in cars)
                {
                    garage.AddCar(car);
                }

                cars = cars.Where(x => x.IsFixed == false).ToArray();

                int removedCarsCount = garage.RemoveFixedCar();

                Assert.AreEqual(removedCarsCount, 2);
                Assert.AreEqual(1, garage.CarsInGarage);
                Assert.AreEqual(GenerateTestReport(cars), garage.Report());
            }

            [Test]
            public void GarageShouldThrowExceptionIfNoFixedCarsAreRemoved()
            {
                Garage garage = new Garage("Wheels", 3);

                Car[] cars = new Car[]
                {
                    new Car("Opel", 3),
                    new Car("Reno", 1),
                    new Car("Jumper", 1)
                };

                foreach (var car in cars)
                {
                    garage.AddCar(car);
                }

                var ex = Assert.Catch<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });

                Assert.AreEqual("No fixed cars available.", ex.Message);
            }

            [Test]
            public void GarageReportShouldWorkCorrectly()
            {
                Garage garage = new Garage("Wheels", 3);

                Car[] cars = new Car[]
                {
                    new Car("Opel", 3),
                    new Car("Reno", 1),
                    new Car("Jumper", 1)
                };

                foreach (var car in cars)
                {
                    garage.AddCar(car);
                }

                Assert.AreEqual(GenerateTestReport(cars), garage.Report());
            }

            private string GenerateTestReport(Car[] cars)
            {
                var reportCars = cars.Where(x => x.IsFixed == false).Select(f => f.CarModel).ToList();
                string carsNames = string.Join(", ", reportCars);
                string report = $"There are {reportCars.Count} which are not fixed: {carsNames}.";

                return report;
            }
        }
    }
}