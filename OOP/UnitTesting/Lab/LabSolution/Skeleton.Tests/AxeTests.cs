using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int axeDamage = 10;
        private const int dummyHealth = 10;
        private const int dummyExp = 10;
        [Test]
        public void AxeLossesDurabilityAfterAttack()
        {
            Axe axe = new Axe(axeDamage, 10);
            Dummy dummy = new Dummy(dummyHealth, dummyExp);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack!");
        }

        [Test]
        public void AttackWithBrokenAxeShouldThrowException()
        {
            Axe axe = new Axe(axeDamage, 0);
            Dummy dummy = new Dummy(dummyHealth, dummyExp);

            Assert.Catch(() =>
            {
                axe.Attack(dummy);
            }, "Axe is broken and can't attack.");
        }
    }
}