using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMemeber(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
