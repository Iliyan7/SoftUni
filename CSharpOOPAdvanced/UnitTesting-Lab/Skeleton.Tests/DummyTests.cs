using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.IsTrue(dummy.Health == 5);
        }

        [Test]
        public void DeadDummyThrowsExceptionAfterAttack()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

        [Test]
        public void DeadDummyGivesXP()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(10);

            Assert.IsTrue(dummy.GiveExperience() == 10);
        }

        [Test]
        public void AliveDummyNotGivesXP()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
        }
    }
}
