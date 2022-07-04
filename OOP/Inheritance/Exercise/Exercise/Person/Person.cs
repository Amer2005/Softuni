using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public abstract class Person
    {
        private int age;
        private string name;

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual int Age
        {
            get => age;
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    age = 0;
                }
            }
        }

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }

        public override string ToString()
        {
            return $"Name: {name}, Age: {age}";
        }
    }
}
