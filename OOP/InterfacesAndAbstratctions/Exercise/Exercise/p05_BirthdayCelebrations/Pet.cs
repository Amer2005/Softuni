using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthdatable
    {
        public Pet(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; private set; }

        public DateTime Birthday { get; private set; }

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
