using System;
using System.Collections.Generic;
using System.Globalization;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            List<IBirthdatable> birthdatables = new List<IBirthdatable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string inhabitantType = inputArgs[0];

                if (inhabitantType == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    DateTime birthday = DateTime.ParseExact(inputArgs[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    IBirthdatable citizen = new Citizen(name, age, id, birthday);

                    birthdatables.Add(citizen);
                }
                else if(inhabitantType == "Pet")
                {
                    string name = inputArgs[1];
                    DateTime birthday = DateTime.ParseExact(inputArgs[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    IBirthdatable pet = new Pet(name, birthday);

                    birthdatables.Add(pet);
                }
            }

            int year = int.Parse(Console.ReadLine());

            foreach (var birthdatable in birthdatables)
            {
                if (birthdatable.IsBornInYear(year))
                {
                    Console.WriteLine($"{birthdatable.Birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
                }
            }
        }
    }
}
