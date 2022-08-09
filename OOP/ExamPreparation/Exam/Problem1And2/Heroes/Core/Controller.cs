using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero hero;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);

                heroes.Add(hero);

                return $"Successfully added Sir { name } to the collection.";
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);

                heroes.Add(hero);

                return $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException($"Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon;

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                throw new InvalidOperationException($"Invalid weapon type.");
            }

            weapons.Add(weapon);

            return $"A {char.ToLower(type[0])}{String.Join("", type.Skip(1))} {weapon.Name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);

            if(hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero { heroName } is well-armed.");
            }

            hero.AddWeapon(weapon);

            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {char.ToLower(weapon.GetType().Name[0])}{weapon.GetType().Name.Substring(1)}.";
        }

        public string StartBattle()
        {
            IMap map = new Map();

            IHero[] fightingHeroes = heroes.Models.ToArray();

            return map.Fight(fightingHeroes);
        }

        public string HeroReport()
        {
            IHero[] fightingHeroes = heroes.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name)
                .ToArray();

            StringBuilder result = new StringBuilder();

            foreach (var hero in fightingHeroes)
            {
                result.Append(hero.ToString() + Environment.NewLine);
            }

            return result.ToString().TrimEnd();
        }
        
    }
}
