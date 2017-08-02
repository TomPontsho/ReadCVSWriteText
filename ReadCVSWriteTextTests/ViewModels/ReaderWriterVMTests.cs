using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCVSWriteText.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.ViewModels.Tests {
    [TestClass()]
    public class ReaderWriterVMTests {
        [TestMethod()]
        public void ReaderWriterVMTest() {
            // Test ViewModel in its initial state
            ReaderWriterVM rwVM = new ReaderWriterVM();

            bool actual = rwVM.runAppCmd.CanExecute(null);
            if (actual)
                rwVM.runAppCmd.Execute(null);
            else
                Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void runAppCmdTestCanExecute1() {

            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.outDir = "";
            bool expected = false;

            bool actual = rwVM.runAppCmd.CanExecute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void runAppCmdTestCanExecute2() {

            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.inCSVFile = null;
            bool expected = false;

            bool actual = rwVM.runAppCmd.CanExecute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void runAppCmdTestCanExecute3() {

            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.outFileNames = "";
            bool expected = false;

            bool actual = rwVM.runAppCmd.CanExecute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void runAppCmdTestCanExecute4() {

            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.outFileAddresses = null;
            bool expected = false;

            bool actual = rwVM.runAppCmd.CanExecute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void clearDataCmdTest() {

            // Test ViewModel in its initial state
            ReaderWriterVM rwVM = new ReaderWriterVM();
            bool expected = false;

            bool actual = rwVM.clearDataCmd.CanExecute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void clearDataCmdTest1() {

            // Test ViewModel in its initial state
            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.runAppCmd.Execute(null);

            bool expected = true;

            bool actual = rwVM.clearDataCmd.CanExecute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void clearDataCmdTest2() {

            // Test ViewModel in its initial state
            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.runAppCmd.Execute(null);
            rwVM.clearDataCmd.Execute(null);

            String expected = "";

            String actual = rwVM.freq9to0NamesAtoZ;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void clearDataCmdTest3() {

            // Test ViewModel in its initial state
            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.runAppCmd.Execute(null);
            rwVM.clearDataCmd.Execute(null);

            String expected = "";

            String actual = rwVM.addressAtoZ0to9;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void clearDataCmdTest4() {

            // Test ViewModel in its initial state
            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.runAppCmd.Execute(null);
            rwVM.clearDataCmd.Execute(null);

            int expected = 0;

            int actual = rwVM.loadedFiles.Count;

            Assert.AreEqual(expected, actual);
        }

    }
}