using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : Identifiable, IBirthdatable
    {
        public Citizen(string name, int age, string id, DateTime birthday)
            : base(id)
        {
            Name = name;
            Age = age;
            Birthday = birthday;
        }


        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; private set; }

        public bool IsBornInYear(int year)
        {
            if(Birthday.Year == year)
            {
                return true;
            }

            return false;
        }
    }
}
