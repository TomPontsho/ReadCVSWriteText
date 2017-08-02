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

            // See if it works

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

            // Can't set null name

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTestNull1() {

            // Can't set null surname

            // Arrange
            String name = "Neo";
            String surname = null;
            Address address = new Address("451B", "Pretorious Street");
            String phoneNumber = "0614589658";

            // Act
            Person person = new Person(name, surname, address, phoneNumber);

            // Assert by ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTestNull2() {

            // Can't set null address

            // Arrange
            String name = "Neo";
            String surname = "Makopo";
            Address address = null;
            String phoneNumber = "0614589658";

            // Act
            Person person = new Person(name, surname, address, phoneNumber);

            // Assert by ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTestNull3() {

            // Can't set null address even as string

            // Arrange
            String name = "Neo";
            String surname = "Makopo";
            String addressStr = null;
            String phoneNumber = "0614589658";

            // Act
            Person person = new Person(name, surname, addressStr, phoneNumber);

            // Assert by ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTestNull4() {

            // Can't set null phone number

            // Arrange
            String name = "Neo";
            String surname = "Makopo";
            String addressStr = "89C Pretorious Street";
            String phoneNumber = null;

            // Act
            Person person = new Person(name, surname, addressStr, phoneNumber);

            // Assert by ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonTestEmpty() {

            // Can't set empty name

            // Arrange
            String name = "";
            String surname = "Maheso";
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
        public void PersonTestEmpty1() {

            // Can't set empty surname

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
        public void PersonTestEmpty2() {

            // Can't set empty address

            // Arrange
            String name = "Pontsho";
            String surname = "Maheso";
            string address = "";
            String phoneNumber = "757458224";

            // Act
            Person person = new Person() {
                name = name,
                surname = surname,
                addressHouseStreet = address,
                phoneNumber = phoneNumber
            };

            // Assert by ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonTestEmpty3() {

            // Can't set empty phone number

            // Arrange
            String name = "Pontsho";
            String surname = "Maheso";
            string address = "65C Andries Street";
            String phoneNumber = "";

            // Act
            Person person = new Person() {
                name = name,
                surname = surname,
                addressHouseStreet = address,
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