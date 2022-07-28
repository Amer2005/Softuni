namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Arena arena = new Arena();

            Assert.AreEqual(arena.Count, 0);
            CollectionAssert.AreEqual(arena.Warriors, new Warrior[] { });
        }

        [Test]
        public void EnrollShouldWorkCorrectly()
        {
            Arena arena = new Arena();

            Warrior customWarrior = new Warrior("Pesho", 20, 50);
            Warrior customWarrior2 = new Warrior("Ree", 10, 60);

            arena.Enroll(customWarrior);
            arena.Enroll(customWarrior2);

            Assert.AreEqual(arena.Count, 2);
            CollectionAssert.AreEqual(arena.Warriors, new Warrior[] { customWarrior, customWarrior2 });
        }

        [Test]
        public void CannotEnrollWarriorsWithSameName()
        {
            Arena arena = new Arena();

            Warrior customWarrior = new Warrior("Pesho", 20, 50);
            Warrior customWarrior2 = new Warrior("Pesho", 10, 60);

            arena.Enroll(customWarrior);

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                arena.Enroll(customWarrior2);
            });

            Assert.AreEqual("Warrior is already enrolled for the fights!", ex.Message);
        }

        [Test]
        public void AttackingShouldGiveCorrectValues()
        {
            Arena arena = CreateTestingArena();

            arena.Fight("Pesho", "Gosho");

            Warrior attacker = arena.Warriors.ToArray()[0];
            Warrior deffender = arena.Warriors.ToArray()[1];

            Assert.AreEqual(50, attacker.HP);
            Assert.AreEqual(40, deffender.HP);
        }

        [Test]
        public void AttackingShouldThrowExceptionIfNameNotFound()
        {
            Arena arena = CreateTestingArena();

            var ex = Assert.Catch<InvalidOperationException>(() =>
            {
                arena.Fight("Peter", "Gosho");
            });

            Assert.AreEqual("There is no fighter with name Peter enrolled for the fights!", ex.Message);
        }

        private Arena CreateTestingArena()
        {
            Arena arena = new Arena();

            arena.Enroll(new Warrior("Pesho", 10, 60));
            arena.Enroll(new Warrior("Gosho", 10, 50));
            arena.Enroll(new Warrior("Reekid", 20, 40));
            arena.Enroll(new Warrior("Meekat", 5, 80));

            return arena;
        }
    }
}
