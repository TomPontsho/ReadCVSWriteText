using LINQtoCSV;
using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Models {
    public class ReadPeopleData {

        #region Constructors 
        public ReadPeopleData() {

            _csvContext = new CsvContext();

            _inputFileDescription = new CsvFileDescription {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
        }
        #endregion // Constructors

        #region Private members
        private CsvContext _csvContext;
        private CsvFileDescription _inputFileDescription;
        #endregion // Private members

        #region Public members
        public IEnumerable<Person> readFromCSV(String csvFile) {

            return _csvContext.Read<Person>(csvFile, _inputFileDescription);
        }

        public IEnumerable<Person> readFromDB(String conInfo) {

            throw new Exception("ReadPeopleData - Not implemented");
        }
        #endregion // Public members
    }
}
