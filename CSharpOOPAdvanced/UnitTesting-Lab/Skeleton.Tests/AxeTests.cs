using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.AreEqual("Axe is broken.", ex.Message);
        }
    }
}
