using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void TestIfHeroGainsXP()
        {
            Hero hero = new Hero(new FakeWeapon());

            Assert.That(hero.XP, Is.EqualTo(0));

            hero.Attack(new FakeTarget());

            Assert.That(hero.XP, Is.EqualTo(1));
        }
    }
}
