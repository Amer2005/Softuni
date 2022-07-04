using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] splittedInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = splittedInput[0];
                int age = int.Parse(splittedInput[1]);
                string gender = splittedInput[2];

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                        default:
                            throw new ArgumentNullException("Invalid input!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invali input!");
                }
                
            }

            Console.WriteLine(String.Join(Environment.NewLine, animals));
        }
    }
}
