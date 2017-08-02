using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCVSWriteText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models.Tests {
    [TestClass()]
    public class PersonTests {
        [TestMethod()]
        public void PersonTest() {

            // Arrange
            String name = "Tom";
            String surname = "Maheso";
            String address = "30 2nd Street";
            String phoneNumber = "0614589658";

            // Act
            Person person = new Person(name, surname, address, phoneNumber);

            // Assert
            Assert.IsNotNull(person);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTestNull() {

            // Arrange
            String name = null;
            String surname = "Maheso";
            Address address = new Address("451B", "Pretorious Street");
            String phoneNumber = "0614589658";

            // Act
            Person person = new Person(name, surname, address, phoneNumber);

            // Assert by ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonTestEmpty() {

            // Arrange
            String name = "Pontsho";
            String surname = "";
            Address address = new Address() {
                houseNumber = "65C",
                streetName = "Andries Street"
            };
            String phoneNumber = "";

            // Act
            Person person = new Person() {
                name = name,
                surname = surname,
                address = address,
                phoneNumber = phoneNumber
            };

            // Assert by ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonTestPhoneNumber() {

            // Arrange
            String name = "Pontsho";
            String surname = "Maheso";
            Address address = new Address("4 Van Der Valt St");
            String phoneNumber = "011 598 6474";

            // Act
            Person person = new Person(name, surname, address, phoneNumber);

            // Assert by ExpectedException
        }
    }
}