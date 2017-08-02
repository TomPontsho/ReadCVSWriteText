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
        public void onRunAppTest() {

            ReaderWriterVM rwVM = new ReaderWriterVM();
            rwVM.onRunApp();

            Assert.IsFalse(false);
        }
    }
}