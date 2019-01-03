namespace Iterator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void TestConsturctorWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Iterator(null),
                                                 "Constructor with null argument should throw ArgumentNullException.");
        }

        [Test]
        public void TestConsturctorWitEmptyArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Iterator(new string[0]),
                                                       "Constructor with empty array argument should throw ArgumentOutOfRangeException.");
        }

        [Test]
        public void TestConstructorSuccessfuly()
        {
            var input = "Create test command".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var iterator = new Iterator(input);
            var collectionMember = typeof(Iterator).GetField("collection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = (IList<string>) collectionMember.GetValue(iterator);
            var expectedCount = input.Skip(1).Count();
            Assert.AreEqual(expectedCount, collection.Count, "The length of the collection is not correct.");
        }

        [Test]
        public void TestHastNextWithManyElements()
        {
            var iterator = new Iterator("Command one two".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(iterator.HasNext,
                          $"{nameof(iterator.HasNext)} should return true because there are many elements in the collection.");
        }

        [Test]
        public void TestHastNextWithOneElement()
        {
            var iterator = new Iterator("Command one".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsFalse(iterator.HasNext,
                           $"{nameof(iterator.HasNext)} should return false because there is only one element in the collection.");
        }

        [Test]
        public void TestHastNextWithEmptyCollection()
        {
            var iterator = new Iterator("Command".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsFalse(iterator.HasNext,
                           $"{nameof(iterator.HasNext)} should return because there are not any elements in the collection.");
        }

        [Test]
        public void TestMoveMethodIfCantMove()
        {
            var iterator = new Iterator("Create one".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
            var indexProperty = typeof(Iterator).GetField("currentIndex", BindingFlags.Instance | BindingFlags.NonPublic);
            var indexBeforeMoving = (int) indexProperty.GetValue(iterator);
            Assert.IsFalse(iterator.Move(),
                           $"{nameof(Iterator.Move)} method should return false because there is only one element in the collection.");
            var indexAfterMoving = (int) indexProperty.GetValue(iterator);
            Assert.AreEqual(indexBeforeMoving, indexAfterMoving, "The private field currentIndex should not be modified.");
        }

        [Test]
        public void TestMoveMethodIfCanMove()
        {
            var iterator = new Iterator("Create one two three".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
            var indexProperty = typeof(Iterator).GetField("currentIndex", BindingFlags.Instance | BindingFlags.NonPublic);
            var indexBeforeMoving = (int) indexProperty.GetValue(iterator);
            Assert.IsTrue(iterator.Move(),
                          $"{nameof(Iterator.Move)} method should return true because there are many elements in the collection.");
            var indexAfterMoving = (int) indexProperty.GetValue(iterator);
            Assert.AreEqual(indexBeforeMoving + 1, indexAfterMoving, "The private field currentIndex should be incremented with one.");
        }

        [Test]
        public void PrintMethodShouldThrowException()
        {
            var iterator = new Iterator("Create".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
            var emptyCollectionPrintException =
                Assert.Throws<InvalidOperationException>(() => iterator.Print(), "Empty collection should not print and throw exception.");
            Assert.That(emptyCollectionPrintException.Message, Is.EqualTo("The collection is empty."));
        }

        [Test]
        public void PrintMethodShouldWorkSuccessfuly()
        {
            var expectedArray = "Create one two".Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var iterator = new Iterator(expectedArray);
            var currentElement = iterator.Print();
            Assert.AreEqual(expectedArray.Skip(1).First(), currentElement, "First element should be printed.");
        }
    }
}