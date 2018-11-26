namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        private const string HeroDoesntGetXpMessage = "Hero doesn't get experience after target dies.";

        [Test]
        public void HeroGainsXpAfterTargetDiesWithFakeObject()
        {
            var axe = new FakeAxe();
            var dummy = new FakeDummy();
            var hero = new Hero("Pesho", axe);
            var expectedXp = hero.Experience + dummy.GiveExperience();
            hero.Attack(dummy);
            Assert.AreEqual(expectedXp, hero.Experience, HeroDoesntGetXpMessage);
        }

        [Test]
        public void HeroGainsXpAfterTargetDiesWithMoq()
        {
            var axe = new Mock<IWeapon>();
            var dummy = new Mock<ITarget>();
            axe.Setup(a => a.AttackPoints)
               .Returns(10);
            axe.Setup(a => a.DurabilityPoints)
               .Returns(10);
            dummy.Setup(d => d.Health)
                 .Returns(0);
            dummy.Setup(d => d.IsDead())
                 .Returns(true);
            dummy.Setup(d => d.GiveExperience())
                 .Returns(20);
            var hero = new Hero("Pesho", axe.Object);
            var expectedXp = hero.Experience + dummy.Object.GiveExperience();
            hero.Attack(dummy.Object);
            Assert.AreEqual(expectedXp, hero.Experience, HeroDoesntGetXpMessage);
        }
    }
}