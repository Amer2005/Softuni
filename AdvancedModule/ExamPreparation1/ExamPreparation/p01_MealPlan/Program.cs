using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace p01_MealPlan
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Meal> meals = new List<Meal>(Console.ReadLine()
                .Split(" ")
                .Select(x => new Meal(x))
                .ToList());

            List<int> caloriesPerDay = new List<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList());

            int currentDay = caloriesPerDay.Count - 1;
            int currentMeal = 0;

            int mealsEaten = 0;

            while (true)
            {
                if (caloriesPerDay[0] == 0 || currentMeal == meals.Count)
                {
                    break;
                }

                if (caloriesPerDay[currentDay] > meals[currentMeal].Calories)
                {
                    caloriesPerDay[currentDay] -= meals[currentMeal].Calories;
                    meals[currentMeal].Calories = 0;
                    currentMeal++;
                    mealsEaten++;
                }
                else
                {
                    meals[currentMeal].Calories -= caloriesPerDay[currentDay];
                    caloriesPerDay[currentDay] = 0;

                    if (currentDay == 0)
                    {
                        mealsEaten++;
                        currentMeal++;
                    }

                    currentDay--;
                }
            }

            if (currentMeal == meals.Count)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {String.Join(", ", caloriesPerDay.SkipLast(caloriesPerDay.Count - 1 - currentDay).Reverse())} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ", meals.Skip(currentMeal).Select(x => x.Name))}.");
            }
        }
    }

    public class Meal
    {
        public Meal(string name)
        {
            Name = name;

            switch (name)
            {
                case "salad":
                    Calories = 350;
                    break;
                case "soup":
                    Calories = 490;
                    break;
                case "pasta":
                    Calories = 680;
                    break;
                case "steak":
                    Calories = 790;
                    break;
                default:
                    break;
            }
        }

        public string Name { get; set; }

        public int Calories { get; set; }
    }
}
