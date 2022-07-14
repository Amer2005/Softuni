using System;
using System.Collections.Generic;
using System.Text;

namespace p03_Raiding.Models
{
    public class Druid : HealerHero
    {
        private const int DruidPower = 80;

        public Druid(string name) : base(name, DruidPower)
        {
        }
    }
}
