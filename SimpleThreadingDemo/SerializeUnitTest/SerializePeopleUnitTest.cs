using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SerializePeople;

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
            string expectedResult = @"Name of the person is: John born on the 2000-10-01";
            Assert.That(serialPeople.p.ToString(), Is.EqualTo(expectedResult);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            serialPeople = null;
        }
    }
}
