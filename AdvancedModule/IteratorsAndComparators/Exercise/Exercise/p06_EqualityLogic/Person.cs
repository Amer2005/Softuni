using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace p05_ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if(this.Name.ToLower().CompareTo(other.Name.ToLower()) != 0)
            {
                return this.Name.ToLower().CompareTo(other.Name.ToLower());
            }

            if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
            {
                return false;
            }

            Person other = (Person)obj;

            return this.CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name.ToLower(), Age);
        }
    }
}
