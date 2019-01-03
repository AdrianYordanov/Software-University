namespace Extended_Database.Tests
{
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class PersonTests
    {
        [Test]
        [TestCase(1, "peho")]
        [TestCase(43542354, "gosho")]
        [TestCase(4234, "tisho")]
        public void ConstructorsInitialization(int id, string username)
        {
            var person = new Person(id, username);
            Assert.IsNotNull(person);
            Assert.AreEqual(person.Id, id);
            Assert.AreEqual(person.Username, username);
        }

        [Test]
        public void PersonHasItsOwnProperties()
        {
            var expectedProperties = new[] {"Username", "Id"};
            var personType = typeof(Person);
            var properties = personType.GetProperties().Select(p => p.Name).ToArray();
            Assert.AreEqual(expectedProperties.Length,
                            properties.Length,
                            $"{nameof(Person)} doesn't {expectedProperties.Length} properties.");
            foreach (var property in expectedProperties)
            {
                Assert.IsTrue(properties.Contains(property), $"{nameof(Person)} doesn't contains {property} property.");
            }
        }
    }
}