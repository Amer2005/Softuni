namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private Person[] invalidPeople;
        private Person[] edgeCasePeople;
        private Person dummyPerson;

        [SetUp]
        public void SetUp()
        {
            people = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho"),
                new Person(3, "Victor"),
                new Person(4, "Dido"),
                new Person(5, "xXxGamerSixNinexXx"),
                new Person(6, "ZiggsBG"),
                new Person(7, "HexitG9"),
                new Person(8, "Anni"),
                new Person(9, "Reko")
            };

            invalidPeople = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho"),
                new Person(3, "Victor"),
                new Person(4, "Dido"),
                new Person(5, "xXxGamerSixNinexXx"),
                new Person(6, "ZiggsBG"),
                new Person(7, "HexitG9"),
                new Person(8, "Anni"),
                new Person(9, "Reko"),
                new Person(10, "Geeko"),
                new Person(11, "Feeder"),
                new Person(12, "Jax"),
                new Person(13, "Heroxx"),
                new Person(14, "Mosiac"),
                new Person(15, "Tree"),
                new Person(16, "NotMe"),
                new Person(17, "NoobGamer"),
            };

            edgeCasePeople = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho"),
                new Person(3, "Victor"),
                new Person(4, "Dido"),
                new Person(5, "xXxGamerSixNinexXx"),
                new Person(6, "ZiggsBG"),
                new Person(7, "HexitG9"),
                new Person(8, "Anni"),
                new Person(9, "Reko"),
                new Person(10, "Geeko"),
                new Person(11, "Feeder"),
                new Person(12, "Jax"),
                new Person(13, "Heroxx"),
                new Person(14, "Mosiac"),
                new Person(15, "Tree"),
                new Person(16, "NotMe"),
            };

            dummyPerson = new Person(144, "Dummy Person");
        }

        [Test]
        public void ConstructorShouldCreateDatabaseCorecctly()
        {
            //Arrange and Act
            Database db = new Database(edgeCasePeople);

            //Assert
            if(!AreAllPeopleInTheDatabase(db, edgeCasePeople))
            {
                Assert.Fail("Not all people are in the database or count is wrong");
            }
        }

        [Test]
        public void ConstructorShouldThrowExcepitonIfMoreThan16People()
        {
            //Arrange and Act
            Assert.Catch<ArgumentException>(() =>
            {
                Database db = new Database(invalidPeople);
            });
        }

        [Test]

        public void AddShouldAddLessThan16People()
        {
            Database db = new Database(people);

            Person newPerson = new Person(144, "Test Dummy");

            Person[] expectedPeople = people.Append(newPerson).ToArray();

            db.Add(newPerson);

            Assert.IsTrue(AreAllPeopleInTheDatabase(db, expectedPeople));
        }

        [Test]
        public void AddShouldNotAddMoreThan16People()
        {
            Database db = new Database(edgeCasePeople);

            Assert.Catch<InvalidOperationException>(() =>
            {
                db.Add(dummyPerson);
            });
        }

        [Test]
        public void AddShouldNotAddPeopleWithSameUsername()
        {
            Database db = new Database(people);

            db.Add(dummyPerson);
            Person newDummy = new Person(133, dummyPerson.UserName);

            Assert.Catch<InvalidOperationException>(() =>
            {
                db.Add(newDummy);
            });
        }

        [Test]
        public void AddShouldNotAddPeopleWithSameId()
        {
            Database db = new Database(people);

            db.Add(dummyPerson);
            Person newDummy = new Person(dummyPerson.Id, "New dummy");

            Assert.Catch<InvalidOperationException>(() =>
            {
                db.Add(newDummy);
            });
        }

        [Test]
        public void RemoveShouldRemoveLastElement()
        {
            Database db = new Database(people);

            db.Remove();

            Person[] expectedPeople = people.SkipLast(1).ToArray();

            Assert.IsTrue(AreAllPeopleInTheDatabase(db, expectedPeople));
        }

        [Test]
        public void RemoveShouldThrowExceptionIfDatabaseIsEmpty()
        {
            Database db = new Database();

            Assert.Catch<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void FindByUsernameShouldGiveCorrectUser()
        {
            Database db = new Database(people);
            Person personToFind = people[0];

            Person resultPerson = db.FindByUsername(personToFind.UserName);

            Assert.That(resultPerson, Is.EqualTo(personToFind));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfUsernameNotFound()
        {
            Database db = new Database(people);

            Assert.Catch<InvalidOperationException>(() =>
            {
                db.FindByUsername("Invalid username");
            });
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfUsernameIsNull()
        {
            Database db = new Database(people);

            Assert.Catch<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsernameShouldBeCaseSensitive()
        {
            Database db = new Database(people);

            Person caseSensitivePerson = new Person(12434, "I am Case Sensitive");

            db.Add(caseSensitivePerson);

            Assert.Catch<InvalidOperationException>(() =>
            {
                db.FindByUsername(caseSensitivePerson.UserName.ToLower());
            });
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfNotFound()
        {
            Database db = new Database(people);

            Assert.Catch<InvalidOperationException>(() =>
            {
                db.FindById(315);
            });
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdIsNegative()
        {
            Database db = new Database(people);

            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-315);
            });
        }

        [Test]
        public void FindByIdShouldGiveCorrectUser()
        {
            Database db = new Database(people);
            Person personToFind = people[0];

            Person resultPerson = db.FindById(personToFind.Id);

            Assert.That(resultPerson, Is.EqualTo(personToFind));
        }

        private bool AreAllPeopleInTheDatabase(Database db, Person[] peopleToCheck)
        {
            for (int i = 0; i < peopleToCheck.Length; i++)
            {
                if (!db.FindById(peopleToCheck[i].Id).Equals(peopleToCheck[i]))
                {
                    return false;
                }
            }

            if(db.Count != peopleToCheck.Length)
            {
                return false;
            }    

            return true;
        }
    }
}