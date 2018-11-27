namespace Database.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private const int ExactlyTheInitialCountOfNumbers = 16;
        private Database database;

        [SetUp]
        public void DatabaseSetUp()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        }

        [Test]
        public void TestIfConstructorDoesNotTakeSixteenNumbers()
        {
            var exUnderSixteen = Assert.Throws<InvalidOperationException>(() =>
            {
                new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            });
            var exAboveSixteen = Assert.Throws<InvalidOperationException>(() =>
            {
                new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            });
            Assert.AreEqual(exUnderSixteen.Message, "There are not exactly sixteen numbers.");
            Assert.AreEqual(exUnderSixteen.Message, exAboveSixteen.Message);
        }

        [Test]
        public void TestFetchMethod()
        {
            var expectedArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Assert.IsTrue(expectedArray.SequenceEqual(this.database.Fetch()), "The database is not same as it was initialize.");
        }

        [Test]
        public void TestRemoveMethd()
        {
            var expectedArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            this.database.Remove();
            Assert.IsTrue(expectedArray.SequenceEqual(this.database.Fetch()),
                          "The add method hasn't been added the two numbers correctly.");
        }

        [Test]
        public void TestRemoveMethodIfThereIsNoDatabase()
        {
            for (var i = 0; i < ExactlyTheInitialCountOfNumbers; i++)
            {
                this.database.Remove();
            }

            var ex = Assert.Throws<InvalidOperationException>(() => this.database.Remove());
            Assert.AreEqual(ex.Message, "You can't remove number, there aren't any numbers.");
        }

        [Test]
        public void TestAddMethod()
        {
            var expectedArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 18 };
            this.database.Remove();
            this.database.Add(18);
            Assert.IsTrue(expectedArray.SequenceEqual(this.database.Fetch()),
                          "The add method hasn't been added the two numbers correctly.");
        }

        [Test]
        public void TestAddMethodIfDbIsFull()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.database.Add(18));
            Assert.AreEqual(ex.Message, "You can't add number, there are already sixteen numbers.");
        }
    }
}