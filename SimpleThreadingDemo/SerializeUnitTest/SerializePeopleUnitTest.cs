using System;
using System.IO;
using NUnit.Framework;

namespace SerializePeople.Test
{
    [TestFixture]
    public class SerializePeopleUnitTest
    {
        SerialPeople serialPeople = null;

        [OneTimeSetUp]
        public void TestSetup()
        {
            serialPeople = new SerialPeople();
        }

        [Test]
        public void Test_InstanceCreation()
        {
            Assert.True(serialPeople.p is Person);
        }

        [Test]
        public void Test_ToStringOfPerson()
        {
            DateTime bornYear = new DateTime(2000, 10, 1);
            string expectedResult = @"Name of the person is: John born on the " + bornYear.ToString();
            string personToString = serialPeople.p.ToString();
            Assert.That(personToString, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_PeopleSerialization()
        {
            if (File.Exists(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat"))
            {
                File.Delete(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat");
            }

            serialPeople.p.Serialize(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat");
            FileAssert.Exists(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat");
            File.Delete(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat");
        }

        [Test]
        public void Test_PeopleDeSerialization()
        {
            if (File.Exists(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat"))
            {
                File.Delete(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat");
            }

            serialPeople.p.Serialize(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat");
            Person p = Person.DeSerialize(@"E:\OneDrive\Codecool\VisualStudio\repos\SI3 - Threading\SimpleThreadingDemo\SerializeUnitTest\streamedPerson.dat");

            bool status = true;
            if (!(p is Person))
            {
                status = false;
            }

            if (p.Name != "John")
            {
                status = false;
            }

            if (p.HumanGender != Person.Gender.Male)
            {
                status = false;
            }

            if (p.BirthDate != new DateTime(2000, 10, 1))
            {
                status = false;
            }

            Assert.True(status);
        }


        [OneTimeTearDown]
        public void TestTearDown()
        {
            serialPeople = null;
        }
    }
}
