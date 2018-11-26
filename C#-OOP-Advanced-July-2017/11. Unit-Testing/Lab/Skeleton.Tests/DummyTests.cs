namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int AxeInitialAttack = 10;
        private const int AxeInitialDurability = 10;
        private const int DummyInitialHealth = 10;
        private const int DummyInitialExperience = 10;
        private Axe axe;

        [SetUp]
        public void AxeSetUp()
        {
            this.axe = new Axe(AxeInitialAttack, AxeInitialDurability);
        }

        [Test]
        public void DummyLosesHalthAfterAttack()
        {
            var dummy = new Dummy(DummyInitialHealth, DummyInitialExperience);
            var expectedDummyHealth = dummy.Health - this.axe.AttackPoints;
            this.axe.Attack(dummy);
            Assert.AreEqual(expectedDummyHealth, dummy.Health, "Dummy doesn't loose enough health.");
        }

        [Test]
        public void AttackOnDeadDummy()
        {
            var dummy = new Dummy(0, DummyInitialExperience);
            var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy),
                                                              "Dummy doesn't throw exception when is dead and attacked.");
            Assert.IsTrue(dummy.IsDead());
            Assert.AreEqual("Dummy is dead.", ex.Message);
        }

        [Test]
        public void DeadDummyShouldGiveXp()
        {
            var dummy = new Dummy(0, DummyInitialExperience);
            var resultExperience = dummy.GiveExperience();
            Assert.AreEqual(resultExperience, DummyInitialExperience, "Dummy doesn't give enough experience.");
        }

        [Test]
        public void AliveDummyShouldNotGiveXp()
        {
            var dummy = new Dummy(DummyInitialHealth, DummyInitialExperience);
            var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
            Assert.AreEqual(ex.Message, "Target is not dead.");
        }
    }
}