using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCVSWriteText.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models.Tests {
    [TestClass()]
    public class WritePeopleDataTests {
        [TestMethod()]
        public void writeToFileTest() {

            // Write out a test file

            WritePeopleData writer = new WritePeopleData();
            string fileName = @".\Resources\testFile.txt";
            writer.writeToFile(fileName, "This is just a test file.");

            Assert.IsTrue(File.Exists(fileName));
        }
    }
}