using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCVSWriteText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models.Tests {
    [TestClass()]
    public class PeopleDataTests {

        [TestMethod()]
        public void hasDataTest() {

            // Should be empty initially
            PeopleData peopleData = new PeopleData();
            bool expected = false;

            bool actual = peopleData.hasData();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void hasDataTest2() {

            // Should have data once added
            PeopleData peopleData = new PeopleData();

            String name = "Pontsho";
            String surname = "Maheso";
            Address address = new Address("184 Van Der Valt St");
            String phoneNumber = "0115986474";
            Person person = new Person(name, surname, address, phoneNumber);

            peopleData.add(person);

            bool expected = true;

            bool actual = peopleData.hasData();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void addTestNull() {

            // Does not allow addition of null person
            PeopleData peopleData = new PeopleData();

            Person person = null;

            peopleData.add(person);
        }

        [TestMethod()]
        public void addTestCount() {

            // Correct count of people as added
            PeopleData peopleData = new PeopleData();

            String name = "Pontsho";
            String surname = "Maheso";
            Address address = new Address("184 Van Der Valt St");
            String phoneNumber = "0115986474";
            Person person = new Person(name, surname, address, phoneNumber);

            peopleData.add(person);

            int expected = 1;

            int actual = peopleData.count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void addTestNull2() {

            // Even addition of a collection should not allow addition of a null Person
            PeopleData peopleData = new PeopleData();

            String name = "Pontsho";
            String surname = "Maheso";
            Address address = new Address("184 Van Der Valt St");
            String phoneNumber = "0115986474";
            Person person1 = new Person(name, surname, address, phoneNumber);

            Person person2 = null;

            List<Person> people = new List<Person> { person1, person2 };

            peopleData.add(people);
        }

        [TestMethod()]
        public void clearDataTest() {

            // Clearing actually removes all added
            String name = "Pontsho";
            String surname = "Maheso";
            Address address = new Address("184 Van Der Valt St");
            String phoneNumber = "0115986474";
            Person person = new Person(name, surname, address, phoneNumber);

            PeopleData peopleData = new PeopleData(new List<Person> { person });

            peopleData.clearData();

            int expected = 0;

            int actual = peopleData.count;

            Assert.AreEqual(expected, actual);
        }
    }
}