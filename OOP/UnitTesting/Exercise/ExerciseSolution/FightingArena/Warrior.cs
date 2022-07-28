using System;

namespace FightingArena
{
    public class Warrior
    {
        private const int MIN_ATTACK_HP = 30;

        private string name;
        private int damage;
        private int hp;

        public Warrior(string name, int damage, int hp)
        {
            this.Name = name;
            this.Damage = damage;
            this.HP = hp;
        }

        public string Name
        {
            get
            {
                //done
                return this.name;
            }
            private set
            {
                //done
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty or whitespace!");
                }

                //done
                this.name = value;
            }
        }

        public int Damage
        {
            get
            {
                //done
                return this.damage;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Damage value should be positive!");
                }

                //done
                this.damage = value;
            }
        }

        public int HP
        {
            get
            {
                //done
                return this.hp;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HP should not be negative!");
                }

                //done
                this.hp = value;
            }
        }

        public void Attack(Warrior warrior)
        {
            if (this.HP <= MIN_ATTACK_HP)
            {
                //done
                throw new InvalidOperationException("Your HP is too low in order to attack other warriors!");
            }

            if (warrior.HP <= MIN_ATTACK_HP)
            {
                //done
                throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
            }

            if (this.HP < warrior.Damage)
            {
                //done
                throw new InvalidOperationException($"You are trying to attack too strong enemy");
            }

            //done
            this.HP -= warrior.Damage;

            if (this.Damage > warrior.HP)
            {
                //done
                warrior.HP = 0;
            }
            else
            {
                //done
                warrior.HP -= this.Damage;
            }
        }
    }
}
