using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durabilty;

        public Weapon(string name, int durabilty)
        {
            this.Name = name;
            this.Durability = durabilty;
        }

        public string Name 
        {
            get => $"{name}"; 
            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(null, "Weapon type cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Durability  
        { 
            get => durabilty;
            protected internal set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }

                durabilty = value;
            }
        }

        public abstract int DoDamage();

        protected int DoDamage(int damage)
        {
            if (Durability > 0)
            {
                Durability--;

                return damage;
            }
            else
            {
                return 0;
            }
        }
    }
}
