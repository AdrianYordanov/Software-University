namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        private const int AxeInitialAttack = 10;
        private const int AxeInitialDurability = 10;
        private const int DummyInitialHealth = 10;
        private const int DummyInitialExperience = 10;
        private Dummy dummy;

        [SetUp]
        public void DummySetUp()
        {
            this.dummy = new Dummy(DummyInitialHealth, DummyInitialExperience);
        }

        [Test]
        public void AxeLooesDurabilityAfterAttack()
        {
            var axe = new Axe(AxeInitialAttack, AxeInitialDurability);
            var axeExpectedDurabilityAfterAttack = axe.DurabilityPoints - 1;
            axe.Attack(this.dummy);
            Assert.AreEqual(axeExpectedDurabilityAfterAttack,
                            axe.DurabilityPoints,
                            "Axe durability doesn't change after attack.");
        }

        [Test]
        public void AxeBecomeBrokenAfterAttackWithNoDurability()
        {
            var axe = new Axe(AxeInitialAttack, 0);
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(this.dummy),
                                                              "Axe doesn't throws exception after attack with zero durability.");
            Assert.AreEqual("Axe is broken.", ex.Message);
        }
    }
}