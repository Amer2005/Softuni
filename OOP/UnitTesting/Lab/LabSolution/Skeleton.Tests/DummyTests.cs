using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int axeDamage = 10;
        private const int axeDurability = 10;
        private const int dummyExp = 10;

        [Test]
        public void DummyShouldLooseHealthIfAttacked()
        {
            const int dummyHealth = 15;

            Axe axe = new Axe(axeDamage, axeDurability);
            Dummy dummy = new Dummy(dummyHealth, dummyExp);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(dummyHealth - axeDamage));
        }

        [Test]
        public void DummyShouldThrowExceptionIfAttackedWhenDead()
        {
            Axe axe = new Axe(axeDamage, axeDurability);
            Dummy dummy = new Dummy(0, dummyExp);

            Assert.Catch(() =>
            {
                axe.Attack(dummy);
            }, "Dummy is dead and should throw exception if attacked!");
        }

        [Test]
        public void DeadDummyShouldGiveExperience()
        {
            Dummy dummy = new Dummy(0, dummyExp);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(dummyExp));
        }

        [Test]
        public void AliveDummyShouldThrowExceptionIfGiveExpIsCalled()
        {
            const int dummyHealth = 15;

            const int dummyExperience = 10;

            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            Assert.Catch(() =>
            {
                dummy.GiveExperience();
            }, "Alive dummies should throw exception if give exp is called!");
        }
    }
}