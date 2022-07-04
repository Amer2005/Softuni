using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name 
        { 
            get => name; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input!");
                }
                else
                {
                    name = value;
                }
            }
        }
       
        public int Age 
        { 
            get => age; 
            set
            {
                if(value < 0)
                {
                    throw new ArgumentNullException("Invalid input!");
                }
                else
                {
                    age = value;
                }
            }
        }
        
        public string Gender 
        { 
            get => gender;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input!");
                }
                else
                {
                    gender = value;
                }
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}");
            result.AppendLine($"{Name} {Age} {Gender}");
            result.Append($"{this.ProduceSound()}");

            return result.ToString();
        }
    }
}
