namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 3 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 ,16 })]
        public void ConstructorShouldAddLessThan16Elements(int[] elements)
        {
            //Arrange
            Database db = new Database(elements);

            //Act
            int[] realData = db.Fetch();
            int[] expectedData = elements;

            int realCount = db.Count;
            int expectedCount = expectedData.Length;

            //Assert
            CollectionAssert.AreEqual(realData, expectedData, 
                "Constructor data is invalid!");
            Assert.That(realCount, Is.EqualTo(expectedCount)
                ,"Wrong count is given after creation of database");
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfMoreThan16Elements()
        {
            //Arrange
            int[] elements = Enumerable.Range(1, 17).ToArray();

            Assert.Catch<InvalidOperationException>(() =>
            {
                Database db = new Database(elements);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddShouldAddLessThan16Elements()
        {
            //Arrange
            int[] elements = Enumerable.Range(1, 15).ToArray();
            Database db = new Database();

            //Act
            for (int i = 0; i < elements.Length; i++)
            {
                db.Add(elements[i]);
            }

            int[] resultElements = db.Fetch();

            //Assert
            CollectionAssert.AreEqual(elements, resultElements);
            Assert.That(db.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void AddShouldThrowExceptionIfMoreThan16ElementsAreAdded()
        {
            //Arrange
            int[] elements = Enumerable.Range(1, 17).ToArray();
            Database db = new Database();

            //Act and Assert
            Assert.Catch<InvalidOperationException>(() =>
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    db.Add(elements[i]);
                }
            });
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 5, 6, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemoveShouldRemoveLastElementCorecctly(int[] elements)
        {
            //Arrange
            Database db = new Database(elements);

            //Act
            db.Remove();
            int[] resultElements = db.Fetch();
            int[] expectedElements = elements.SkipLast(1).ToArray();

            CollectionAssert.AreEqual(expectedElements, resultElements);
            Assert.That(db.Count, Is.EqualTo(expectedElements.Length));
        }

        [Test]
        public void RemoveShouldRemoveLastElementMoreThanOnce()
        {
            //Arrange
            int[] elements = new int[] { 1, 3, 9, 145 };
            Database db = new Database(elements);

            for (int i = 0; i < elements.Length; i++)
            {
                db.Remove();
            }

            int[] resultData = db.Fetch();
            int[] expectedData = new int[] { };

            int resultCount = db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, resultData);
            Assert.That(expectedCount, Is.EqualTo(resultCount));
        }

        [Test]
        public void RemoveShouldThrowExceptionIfDatabaseIsEmpty()
        {
            //Arrange
            Database db = new Database();

            //Act and Assert
            Assert.Catch<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 5, 6, 8 })]
        public void FetchShouldReturnCorrectArray(int[] elements)
        {
            Database db = new Database(elements);

            int[] resultElements = db.Fetch();

            CollectionAssert.AreEqual(elements, resultElements);
        }
    }
}
