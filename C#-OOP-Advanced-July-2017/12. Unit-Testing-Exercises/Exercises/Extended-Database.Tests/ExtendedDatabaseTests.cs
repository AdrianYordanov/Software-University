namespace Extended_Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase db;

        [SetUp]
        public void ExtendedDatabaseSetup()
        {
            this.db = new ExtendedDatabase();
        }

        [Test]
        public void EmptyConstructorInitialization()
        {
            Assert.AreEqual(0, this.db.Persons.Length, "Empty constructor doesn't create empty collection.");
        }

        [Test]
        public void ArgumentConstructorInitialization()
        {
            var persons = new[] {new Person(0, "Peter"), new Person(1, "Stamat"), new Person(34353, "Peter")};
            var database = new ExtendedDatabase(persons[0], persons[1], persons[2]);
            Assert.AreEqual(persons.Length,
                            database.Persons.Length,
                            "Constructor creates collection with lenght different of the arguments count.");
        }

        [Test]
        public void AddMethodByUsernameCreatesSuccessfully()
        {
            var person = new Person(1, "Peter");
            this.db.Add(person);
            Assert.AreEqual(this.db.Persons[0].Username, person.Username, "Add method adds method with different username.");
        }

        [Test]
        public void AddMethodByUsernameWithExistingUsername()
        {
            var firstPeter = new Person(1, "Peter");
            var secondPeter = new Person(2, "Peter");
            this.db.Add(firstPeter);
            var exFromInvalidUsername = Assert.Throws<InvalidOperationException>(() => this.db.Add(secondPeter));
            Assert.That(exFromInvalidUsername.Message, Is.EqualTo($"There is already person with this username: {secondPeter.Username}."));
        }

        [Test]
        public void AddMethodByUsernameWithExistingId()
        {
            var firstPeter = new Person(1, "Peter");
            var secondPeter = new Person(1, "Stamat");
            this.db.Add(firstPeter);
            var exFromInvalidUsername = Assert.Throws<InvalidOperationException>(() => this.db.Add(secondPeter));
            Assert.That(exFromInvalidUsername.Message, Is.EqualTo($"There is already person with this id: {secondPeter.Id}."));
        }

        [Test]
        public void FindPersonByNameSucessfully()
        {
            var person = new Person(1, "Peter");
            this.db.Add(person);
            var samePerson = this.db.Find(person.Username);
            Assert.AreEqual(person, samePerson);
        }

        [Test]
        public void FindPersonByIdSucessfully()
        {
            var person = new Person(1, "Peter");
            this.db.Add(person);
            var samePerson = this.db.Find(person.Id);
            Assert.AreEqual(person, samePerson);
        }

        [Test]
        [TestCase("random name")]
        [TestCase("not existing name")]
        public void FindPersonByNoneExistingName(string searchingName)
        {
            var exceptionNotFoundPersonByName = Assert.Throws<InvalidOperationException>(() => this.db.Find(searchingName));
            Assert.That(exceptionNotFoundPersonByName.Message, Is.EqualTo($"There is no person with this username: {searchingName}"));
        }

        [Test]
        public void FindPersonByNameWithNull()
        {
            var exFromNullSearching = Assert.Throws<ArgumentNullException>(() => this.db.Find(null));
            Assert.That(exFromNullSearching.ParamName, Is.EqualTo("username"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(352456)]
        public void FindPersonByNoneExistingId(int searchingId)
        {
            var exceptionNotFoundPersonByName = Assert.Throws<InvalidOperationException>(() => this.db.Find(searchingId));
            Assert.That(exceptionNotFoundPersonByName.Message, Is.EqualTo($"There is no person with this id: {searchingId}"));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-76574)]
        [TestCase(-32435353425)]
        public void FindPersonByNameWithNegativeId(long id)
        {
            var exFromNegativeSearching = Assert.Throws<ArgumentOutOfRangeException>(() => this.db.Find(id));
            Assert.That(exFromNegativeSearching.ParamName, Is.EqualTo("id"));
        }

        [Test]
        public void RemoveExistingPerson()
        {
            var person = new Person(1, "Peter");
            this.db.Add(person);
            this.db.Remove(person);
            Assert.AreEqual(0, this.db.Persons.Length);
        }

        [Test]
        public void RemoveNoneExistingPerson()
        {
            var person = new Person(1, "Peter");
            this.db.Remove(person);
            Assert.AreEqual(0, this.db.Persons.Length);
        }
    }
}