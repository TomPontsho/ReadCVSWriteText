using Microsoft.Win32;
using ReadCVSWriteText.Models;
using ReadCVSWriteText.Services;
using ReadCVSWriteText.Services.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ReadCVSWriteText.ViewModels {

    /// <summary>
    /// The ViewModel, used by ReaderWriterV.
    /// </summary>
    public class ReaderWriterVM : BindableVM {

        #region Constructor
        public ReaderWriterVM() {

            String currDir = Directory.GetCurrentDirectory();

            outDir = currDir + @"\Resources";
            inCSVFile = outDir + @"\data.csv";
        }
        #endregion // Constructor

        #region Private members
        private ReadPeopleData _reader = new ReadPeopleData();
        private WritePeopleData _writer = new WritePeopleData();
        private PeopleData _peopleData = new PeopleData();
        #endregion // Private members

        #region Public members
        public static readonly string NAMINGINVALIDCHARS = "/:*?<>|\\\"";

        private String _inCSVFile = "";
        /// <summary>
        /// The CSV file to read
        /// </summary>
        public String inCSVFile {
            get { return _inCSVFile; }
            set {
                if(_inCSVFile != value) {
                    _inCSVFile = value;
                    onPropertyChanged(nameof(inCSVFile));
                }
            }
        }
        private String _outDir = "";
        /// <summary>
        /// The directory to write to
        /// </summary>
        public String outDir {
            get { return _outDir; }
            set {
                if (_outDir != value) {
                    _outDir = value;
                    onPropertyChanged(nameof(outDir));
                }
            }
        }
        private String _outFileNames = "names.txt";
        /// <summary>
        /// The name of the file storing names order by frequency descending, then name ascending
        /// </summary>
        public String outFileNames {
            get { return _outFileNames; }
            set {
                if (_outFileNames != value) {
                    _outFileNames = value;
                    onPropertyChanged(nameof(outFileNames));
                }
            }
        }
        private String _outFileAddresses = "addresses.txt";
        /// <summary>
        /// The name of the file storing addresses order by street name ascending
        /// </summary>
        public String outFileAddresses {
            get { return _outFileAddresses; }
            set {
                if (_outFileAddresses != value) {
                    _outFileAddresses = value;
                    onPropertyChanged(nameof(outFileAddresses));
                }
            }
        }
        private String _status = "Click Run App!";
        /// <summary>
        /// Indicated the status of the application
        /// </summary>
        public String status {
            get { return _status; }
            set {
                if (_status != value) {
                    _status = value;
                    onPropertyChanged(nameof(status));
                }
            }
        }
        private ObservableCollection<String> _loadedFiles = new ObservableCollection<string>();
        /// <summary>
        /// Stores the names of the files the user has loaded so far
        /// </summary>
        public ObservableCollection<String> loadedFiles {
            get { return _loadedFiles; }
            set {
                if (_loadedFiles != value) {
                    _loadedFiles = value;
                    onPropertyChanged(nameof(loadedFiles));
                }
            }
        }

        private String _freq9to0NamesAtoZ = "";
        /// <summary>
        /// The results for sorting users by name frequency descending, then name ascending
        /// </summary>
        public String freq9to0NamesAtoZ {
            get { return _freq9to0NamesAtoZ; }
            set {
                if (_freq9to0NamesAtoZ != value) {
                    _freq9to0NamesAtoZ = value;
                    onPropertyChanged(nameof(freq9to0NamesAtoZ));
                }
            }
        }
        private String _addressAtoZ0to9 = "";
        /// <summary>
        /// The results for sorting addresses order by street name ascending
        /// </summary>
        public String addressAtoZ0to9 {
            get { return _addressAtoZ0to9; }
            set {
                if (_addressAtoZ0to9 != value) {
                    _addressAtoZ0to9 = value;
                    onPropertyChanged(nameof(addressAtoZ0to9));
                }
            }
        }
        #endregion // Public members

        #region Commnads handlers
        private void onSelectInputCSV() {

            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.InitialDirectory = outDir;

            Console.WriteLine(Directory.GetCurrentDirectory());

            String currDir = Directory.GetCurrentDirectory();

            fileDialog.DefaultExt = ".csv";
            fileDialog.Filter = "CSV File |*.csv";

            bool? browseResult = fileDialog.ShowDialog();

            if (browseResult != null && browseResult == true) {

                if (File.Exists(fileDialog.FileName)) {

                    inCSVFile = fileDialog.FileName;
                    outDir = Path.GetDirectoryName(_inCSVFile);
                }
            }
            else {
                Logger.instance.log("ReaderWriterVM - No file selected.", Category.Warn, Priority.Low);
            }
        }

        private void onSelectOutputDir() {

            using (var folderDialog = new FolderBrowserDialog()) { 

                DialogResult browseResult = folderDialog.ShowDialog();

                if (browseResult == DialogResult.OK && 
                    !string.IsNullOrWhiteSpace(folderDialog.SelectedPath)) {

                    outDir = folderDialog.SelectedPath;
                }
                else {
                    Logger.instance.log("ReaderWriterVM - Out put folder not selected.", Category.Warn, Priority.Low);
                }
            }
        }

        private void onRunApp() {

            try {
                // Read the CSV file
                IEnumerable<Person> people = _reader.readFromCSV(_inCSVFile);
                // Store data in a model
                _peopleData.add(people);

                // Get ordered by Frequency descendin and name ascending
                String freqNames = _peopleData.analyze(Analyzers.freq9to0NamesAtoZ);
                // Write freq9to0NamesAtoZ to file
                _writer.writeToFile(_outDir + "\\" + _outFileNames, freqNames);
                // Update view
                freq9to0NamesAtoZ = freqNames;

                // Get ordered by address ascending
                String addresses = _peopleData.analyze(Analyzers.addressAtoZ0to9);
                // Write addressAtoZ0to9 to file
                _writer.writeToFile(_outDir + "\\" + _outFileAddresses, addresses);
                // Update view
                addressAtoZ0to9 = addresses;

                // Log success
                Logger.instance.log("ReaderWriterVM - Successfully loaded: '" + inCSVFile + "'.", 
                    Category.Info, Priority.Low);

                // Add to list of loaded files
                loadedFiles.Add(Path.GetFileName(_inCSVFile));

                // Update read status
                status = "Success!";
            }
            catch (Exception e) {

                // Log exception
                Logger.instance.log("ReaderWriterVM - For file: '" + inCSVFile + "'. " + e.StackTrace,
                    Category.Exception, Priority.Medium);
            }

        }
        private bool canRunApp() {

            return File.Exists(inCSVFile) && Directory.Exists(outDir) &&
                !String.IsNullOrEmpty(outFileNames) && !String.IsNullOrEmpty(outFileAddresses);
        }

        private void onclearData() {

            _peopleData.clearData();
            loadedFiles.Clear();
            freq9to0NamesAtoZ = "";
            addressAtoZ0to9 = "";
            status = "Click Run App!";
        }
        #endregion // Commands handlers

        #region Commands
        private ICommand _selectInputCSVCmd;
        public ICommand selectInputCSVCmd {
            get {
                return _selectInputCSVCmd ?? (
                  _selectInputCSVCmd = new RelayCommand(
                      onSelectInputCSV, () => true));
            }
        }

        private ICommand _selectOutputDirCmd;
        public ICommand selectOutputDirCmd {
            get {
                return _selectOutputDirCmd ?? (
                  _selectOutputDirCmd = new RelayCommand(
                      onSelectOutputDir, () => true));
            }
        }

        private ICommand _runAppCmd;
        /// <summary>
        /// Runs app. Loads user, analyzes then and then presents/stores
        /// </summary>
        public ICommand runAppCmd {
            get {
                return _runAppCmd ?? (
                  _runAppCmd = new RelayCommand(
                      onRunApp, canRunApp));
            }
        }

        private ICommand _clearDataCmd;
        /// <summary>
        /// Clear all the peoples, returns it how it was. 
        /// Thought does not change directories and file names
        /// </summary>
        public ICommand clearDataCmd {
            get {
                return _clearDataCmd ?? (
                  _clearDataCmd = new RelayCommand(
                      onclearData, () => loadedFiles.Count > 0));
            }
        }
        #endregion // Commands
    }
}
