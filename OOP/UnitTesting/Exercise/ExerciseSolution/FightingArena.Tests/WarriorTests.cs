namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const string Name = "Hero";
        private const int Damage = 10;
        private const int HP = 50;

        private const int MIN_ATTACK_HP = 30;

        [Test]
        public void ConstructorShouldGiveCorrectValues()
        {
            string expectedName = Name;
            int expectedDamage = Damage;
            int expectedHP = HP;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.That(expectedName, Is.EqualTo(warrior.Name));
            Assert.That(expectedDamage, Is.EqualTo(warrior.Damage));
            Assert.That(expectedHP, Is.EqualTo(warrior.HP));
        }

        [Test]
        public void NameShouldNotBeNull()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(null, Damage, HP);
            });

            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }

        [Test]
        public void NameShouldNotBeEmpty()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("  ", Damage, HP);
            });

            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }

        [Test]
        public void DamageCannotBeNegativeOrZero()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(Name, 0, HP);
            });

            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }

        [Test]
        public void HPCannotBeNegative()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(Name, Damage, -3);
            });

            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [Test]
        public void WarriorShouldThrowExceptionIfAttackingWithBelow30HP()
        {
            Warrior warriorToAttack = new Warrior(Name, Damage, HP);

            Warrior warrior = new Warrior(Name, Damage, MIN_ATTACK_HP);

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }

        [Test]
        public void ShouldNotAttackLowHPWarrior()
        {
            Warrior warriorToAttack = new Warrior(Name, Damage, MIN_ATTACK_HP);

            Warrior warrior = new Warrior(Name, Damage, HP);

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });

            Assert.AreEqual($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!", ex.Message);
        }

        [Test]
        public void AttackingStrongerEnemyShouldThrowException()
        {
            Warrior warriorToAttack = new Warrior(Name, 50, HP);

            Warrior warrior = new Warrior(Name, Damage, 40);

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });

            Assert.AreEqual($"You are trying to attack too strong enemy", ex.Message);
        }

        [Test]
        public void AttackingEnemyShouldGiveCorrectValues()
        {
            Warrior warrior = new Warrior(Name, 10 , 60);

            Warrior warriorToAttack = new Warrior("Gosho", 5, 50);

            warrior.Attack(warriorToAttack);

            Assert.That(55, Is.EqualTo(warrior.HP));
            Assert.That(40, Is.EqualTo(warriorToAttack.HP));
        }

        [Test]
        public void KillingEnemyShouldGiveCorrectValues()
        {
            Warrior warrior = new Warrior(Name, 60, 60);

            Warrior warriorToAttack = new Warrior("Gosho", 5, 50);

            warrior.Attack(warriorToAttack);

            Assert.That(55, Is.EqualTo(warrior.HP));
            Assert.That(0, Is.EqualTo(warriorToAttack.HP));
        }
    }
}