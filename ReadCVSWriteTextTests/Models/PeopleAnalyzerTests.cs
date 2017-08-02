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

            String name = "Pontsho";
            String surname = "Maheso";
            Address address = new Address("184 Van Der Valt St");
            String phoneNumber = "0115986474";
            Person person1 = new Person(name, surname, address, phoneNumber);

            Person person2 = new Person(name, surname, address, phoneNumber) {
                name = "Tom",
                surname = "Maheso",
                addressHouseStreet = "321 Woodland St",
                phoneNumber = "98563247"
            };

            Person person3 = new Person(name, surname, address, phoneNumber) {
                name = "Thabo",
                surname = "Pontsho",
                address = new Address("21 3rd Street"),
                phoneNumber = "089248753"
            };

            PeopleData peopleData = new PeopleData(new List<Person> { person1, person2, person3 });

            String outText = peopleData.analyze(PeopleAnalyzer.freq9to0NamesZtoA);

            Logger.instance.log(outText, Category.Debug, Priority.Low);

            Assert.IsNotNull(outText);
        }

        [TestMethod()]
        public void addressAtoZTest() {

            String name = "Pontsho";
            String surname = "Maheso";
            Address address = new Address("184 Van Der Valt St");
            String phoneNumber = "0115986474";
            Person person1 = new Person(name, surname, address, phoneNumber);

            Person person2 = new Person(name, surname, address, phoneNumber) {
                name = "Tom",
                surname = "Maheso",
                addressHouseStreet = "321 Woodland St",
                phoneNumber = "98563247"
            };

            Person person3 = new Person(name, surname, address, phoneNumber) {
                name = "Thabo",
                surname = "Pontsho",
                address = new Address("21 3rd Street"),
                phoneNumber = "089248753"
            };

            PeopleData peopleData = new PeopleData(new List<Person> { person1, person2, person3 });

            String outText = peopleData.analyze(PeopleAnalyzer.addressAtoZ0to9);

            Logger.instance.log(outText, Category.Debug, Priority.Low);

            Assert.IsNotNull(outText);
        }
    }
}