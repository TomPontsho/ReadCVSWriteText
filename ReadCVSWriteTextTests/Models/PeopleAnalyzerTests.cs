using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCVSWriteText.Models;
using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models.Tests {
    [TestClass()]
    public class PeopleAnalyzerTests {
        [TestMethod()]
        public void freq9to0NamesZtoATest() {

            String name = "Matt";
            String surname = "Brown";
            Address address = new Address("31 Clifton Rd");
            String phoneNumber = "0115986474";
            Person person1 = new Person(name, surname, address, phoneNumber);

            Person person2 = new Person(name, surname, address, phoneNumber) {
                name = "Heinrich",
                surname = "Jones",
                addressHouseStreet = "12 Acton St",
                phoneNumber = "98563247"
            };

            Person person3 = new Person(name, surname, address, phoneNumber) {
                name = "Johnson",
                surname = "Smith",
                address = new Address("22 Jones Rd"),
                phoneNumber = "089248753"
            };

            Person person4 = new Person(name, surname, address, phoneNumber) {
                name = "Tim",
                surname = "Johnson",
                address = new Address("65 Brown Rd"),
                phoneNumber = "013586445"
            };

            String expected = "Johnson, 2" + Environment.NewLine +
                               "Brown, 1" + Environment.NewLine +
                               "Heinrich, 1" + Environment.NewLine +
                               "Jones, 1" + Environment.NewLine +
                               "Matt, 1" + Environment.NewLine +
                               "Smith, 1" + Environment.NewLine +
                               "Tim, 1" + Environment.NewLine;

            String actual = PeopleAnalyzer.freq9to0NamesZtoA(new List<Person> { person1, person2, person3, person4 });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void addressAtoZTest() {

            String name = "Matt";
            String surname = "Brown";
            Address address = new Address("31 Clifton Rd");
            String phoneNumber = "0115986474";
            Person person1 = new Person(name, surname, address, phoneNumber);

            Person person2 = new Person(name, surname, address, phoneNumber) {
                name = "Heinrich",
                surname = "Jones",
                addressHouseStreet = "12 Acton St",
                phoneNumber = "98563247"
            };

            Person person3 = new Person(name, surname, address, phoneNumber) {
                name = "Johnson",
                surname = "Smith",
                address = new Address("22 Jones Rd"),
                phoneNumber = "089248753"
            };

            Person person4 = new Person(name, surname, address, phoneNumber) {
                name = "Tim",
                surname = "Johnson",
                address = new Address("65 Brown Rd"),
                phoneNumber = "013586445"
            };

            String expected = "12 Acton St" + Environment.NewLine +
                              "65 Brown Rd" + Environment.NewLine +
                              "31 Clifton Rd" + Environment.NewLine +
                              "22 Jones Rd" + Environment.NewLine;

            String actual = PeopleAnalyzer.addressAtoZ0to9(new List<Person> { person1, person2, person3, person4 });

            Assert.AreEqual(expected, actual);
        }
    }
}