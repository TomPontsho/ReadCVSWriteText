﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCVSWriteText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models.Tests {
    [TestClass()]
    public class AddressTests {
        [TestMethod()]
        public void AddressTest() {

            // Ensure it just works
            String streetAddress = "1313 Main Road";

            Address address = new Address(streetAddress);

            Assert.IsNotNull(address);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddressTestInvalidForm1() {

            // House number and street name must be seperated by space
            String streetAddress = "1313MainRoad";

            Address address = new Address(streetAddress);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddressTestInvalidForm2() {

            // First charactor should be a number
            String streetAddress = "Main Road 1313";

            Address address = new Address(streetAddress);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressTestNull() {
            // Can create address
            String streetAddress = null;

            Address address = new Address(streetAddress);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddressTestEmptyHouse() {

            // Empty house number not allowed
            String houseNumber = "";
            String streetName = "Madiba Street";

            Address address = new Address(houseNumber, streetName);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddressTestEmptyStreet() {

            // Empty street name not allowed
            String houseNumber = "58";
            String streetName = "";

            Address address = new Address();

            address.houseNumber = houseNumber;
            address.streetName = streetName;
        }

        [TestMethod()]
        public void AddressTestNoInit() {

            // Un-initialized state should not crash the code getters
            Address address = new Address();

            String streetAddress = address.houseStreet;

            Assert.IsNotNull(streetAddress);
        }
    }
}