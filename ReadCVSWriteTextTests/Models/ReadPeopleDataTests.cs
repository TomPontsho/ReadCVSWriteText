using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCVSWriteText.Models;
using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models.Tests {
    [TestClass()]
    public class ReadPeopleDataTests {

        [TestMethod()]
        public void readFromCSVTest() {

            // Using defalt file, see if it exists

            ReadPeopleData reader = new ReadPeopleData();
            String randomFile = @"./Resources/data.csv";

            var people = reader.readFromCSV(randomFile);

            Assert.IsTrue(people.Count() > 0);
        }
    }
}