using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : Identifiable, IBirthdatable, IBuyer
    {
        public Citizen(string name, int age, string id, DateTime birthday)
            : base(id)
        {
            Name = name;
            Age = age;
            Birthday = birthday;
            Food = 0;
        }


        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            Food += 10;

            return 10;
        }

        public bool IsBornInYear(int year)
        {
            if (Birthday.Year == year)
            {
                return true;
            }

            return false;
        }
    }
}
