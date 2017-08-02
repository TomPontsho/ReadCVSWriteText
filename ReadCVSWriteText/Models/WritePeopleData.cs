using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models {

    /// <summary>
    /// Writes given data to a file
    /// </summary>
    public class WritePeopleData {

        #region Constructors 
        public WritePeopleData() {
        }
        #endregion // Constructors

        #region Private members
        #endregion // Private members

        #region Public members
        /// <summary>
        /// Writes the given data, to the given file
        /// </summary>
        /// <param name="txtFile">File to write to</param>
        /// <param name="data">Data to be written to file</param>
        public void writeToFile(String txtFile, String data) {

            File.WriteAllText(txtFile, data);
        }
        public void writeToDB(String conInfo, IEnumerable<Person> people) {

            throw new Exception("WritePeopleData - Not implemented");
        }
        #endregion // Public members
    }
}
