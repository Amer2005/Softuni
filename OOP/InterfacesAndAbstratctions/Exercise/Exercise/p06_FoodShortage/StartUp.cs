using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IBuyer buyer;

                if (inputArgs.Length == 4)
                {
                    string humanName = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];
                    DateTime birthday = DateTime.ParseExact(inputArgs[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    buyer = new Citizen(humanName, age, id, birthday);
                }
                else
                {
                    string humanName = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string group = inputArgs[2];

                    buyer = new Rebel(humanName, age, group);
                }

                buyers.Add(buyer);
            }

            string name;

            int foodBought = 0;

            while ((name = Console.ReadLine()) != "End")
            {
                if (buyers.Any(x => x.Name == name))
                {
                    IBuyer buyer = buyers.FirstOrDefault(x => x.Name == name);

                    foodBought += buyer.BuyFood();
                }
            }

            Console.WriteLine(foodBought);
        }
    }
}
