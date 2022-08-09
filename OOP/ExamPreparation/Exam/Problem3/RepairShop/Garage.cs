using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairShop
{
    public class Garage
    {
        private string name;
        private int mechanicsAvailable;
        private List<Car> cars;

        //done
        public Garage(string name, int mechanicsAvailable)
        {
            this.Name = name;
            this.MechanicsAvailable = mechanicsAvailable;
            this.cars = new List<Car>();
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
                    throw new ArgumentNullException(nameof(value), "Invalid garage name.");
                }

                //done
                this.name = value;
            }
        }

        public int MechanicsAvailable
        {
            get
            {
                //done
                return this.mechanicsAvailable;
            }

            private set
            {
                if (value <= 0)
                {
                    //done
                    throw new ArgumentException("At least one mechanic must work in the garage.");
                }

                //done
                this.mechanicsAvailable = value;
            }
        }

        //done
        public int CarsInGarage => this.cars.Count;

        public void AddCar(Car car)
        {
            if (this.cars.Count == this.mechanicsAvailable)
            {
                //done
                throw new InvalidOperationException("No mechanic available.");
            }

            //done
            this.cars.Add(car);
        }

        public Car FixCar(string carModel)
        {
            Car carToFix = this.cars.FirstOrDefault(x => x.CarModel == carModel);

            if (carToFix == null)
            {
                //done
                throw new InvalidOperationException($"The car {carModel} doesn't exist.");
            }

            //done
            carToFix.NumberOfIssues = 0;

            return carToFix;
        }

        public int RemoveFixedCar()
        {
            var carsToRemove = this.cars.Where(x => x.IsFixed == true).ToList();

            if (carsToRemove.Count == 0)
            {
                //done
                throw new InvalidOperationException($"No fixed cars available.");
            }

            //done
            return this.cars.RemoveAll(x => x.IsFixed == true);
        }

        public string Report()
        {
            //done
            var reportCars = this.cars.Where(x => x.IsFixed == false).Select(f => f.CarModel).ToList();
            string carsNames = string.Join(", ", reportCars);
            string report = $"There are {reportCars.Count} which are not fixed: {carsNames}.";

            return report;
        }
    }
}
