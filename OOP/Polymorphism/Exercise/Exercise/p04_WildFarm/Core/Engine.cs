using p04_WildFarm.Exceptions;
using p04_WildFarm.Factories;
using p04_WildFarm.Factories.Interfaces;
using p04_WildFarm.Models.Animals;
using p04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p04_WildFarm.Core
{
    public class Engine : IEngine
    {
        public void Start()
        {
            List<Animal> animals = new List<Animal>();

            string input;

            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double animalWeight = double.Parse(animalArgs[2]);

                animalArgs = animalArgs.Skip(3).ToArray();

                Animal animal = animalFactory.CreateAnimal(animalType, animalName, animalWeight, animalArgs);

                Food food = foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));

                Console.WriteLine(animal.ProduceSound());
                try
                {
 
                    animal.Eat(food);
                }
                catch (FoodNotEatenByAnimalException e)
                {
                    Console.WriteLine(e.Message);
                }

                animals.Add(animal);
            }

            Console.WriteLine(String.Join(Environment.NewLine, animals));
        }
    }
}
