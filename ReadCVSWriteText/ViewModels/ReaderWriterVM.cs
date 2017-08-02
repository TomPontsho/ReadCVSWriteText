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
    public class ReaderWriterVM : BindableVM {

        #region Constructor
        public ReaderWriterVM() { }
        #endregion // Constructor

        #region Private members
        private ReadPeopleData _reader = new ReadPeopleData();
        private WritePeopleData _writer = new WritePeopleData();
        private PeopleData _peopleData = new PeopleData();
        #endregion // Private members

        #region Public members
        private String _inCSVFile = @"C:\Users\TMaheso\Documents\Visual Studio 2015\Projects\ReadCVSWriteText\ReadCVSWriteTextTests\bin\Debug\Resources\data.csv";
        public String inCSVFile {
            get { return _inCSVFile; }
            set {
                if(_inCSVFile != value) {
                    _inCSVFile = value;
                    onPropertyChanged(nameof(inCSVFile));
                }
            }
        }
        private String _outDir = @".\Resources\";
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
        public String outFileAddresses {
            get { return _outFileAddresses; }
            set {
                if (_outFileAddresses != value) {
                    _outFileAddresses = value;
                    onPropertyChanged(nameof(outFileAddresses));
                }
            }
        }
        private String _readOutCome = "Nothing read";
        public String readOutCome {
            get { return _readOutCome; }
            set {
                if (_readOutCome != value) {
                    _readOutCome = value;
                    onPropertyChanged(nameof(readOutCome));
                }
            }
        }
        private ObservableCollection<String> _loadedFiles = new ObservableCollection<string>();
        public ObservableCollection<String> loadedFiles {
            get { return _loadedFiles; }
            set {
                if (_loadedFiles != value) {
                    _loadedFiles = value;
                    onPropertyChanged(nameof(loadedFiles));
                }
            }
        }
        public ObservableCollection<String> logs {
            get { return Logger.instance.logs; }
            private set {}
            
        }
        #endregion // Public members

        #region Commnads handlers
        public void onSelectInputCSV() {

            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.InitialDirectory = outDir;

            fileDialog.DefaultExt = ".csv";
            fileDialog.Filter = "CSV File |*.csv";

            bool? browseResult = fileDialog.ShowDialog();

            if (browseResult != null && browseResult == true) {

                if (File.Exists(fileDialog.FileName)) {

                    inCSVFile = fileDialog.FileName;
                    outDir = Path.GetDirectoryName(_inCSVFile) + "\\";
                }
            }
            else {
                Logger.instance.log("ReaderWriterVM - No file selected.", Category.Warn, Priority.Low);
            }
        }

        public void onSelectOutputDir() {

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

        public void onRunApp() {

            try {
                // Read the CSV file
                IEnumerable<Person> people = _reader.readFromCSV(_inCSVFile);
                // Store data in a model
                _peopleData.add(people);

                // Get ordered by Frequency descendin and name ascending
                String freqNames = _peopleData.analyze(PeopleAnalyzer.freq9to0NamesZtoA);
                // Write freq9to0NamesZtoA to file
                _writer.writeToFile(_outDir + "\\" + _outFileNames, freqNames);

                // Get ordered by address ascending
                String addresses = _peopleData.analyze(PeopleAnalyzer.addressAtoZ0to9);
                // Write addressAtoZ0to9 to file
                _writer.writeToFile(_outDir + "\\" + _outFileAddresses, addresses);

                // Log success
                Logger.instance.log("ReaderWriterVM - Successfully loaded: '" + inCSVFile + "'.", 
                    Category.Info, Priority.Low);

                // Add to list of loaded files
                loadedFiles.Add(Path.GetFileName(_inCSVFile));

                // Update read status
                readOutCome = "Success!";
            }
            catch (Exception e) {

                // Log exception
                Logger.instance.log("ReaderWriterVM - For file: '" + inCSVFile + "'. " + e.StackTrace,
                    Category.Exception, Priority.Medium);
            }

        }
        public bool canRunApp() {

            return File.Exists(inCSVFile) && Directory.Exists(outDir) &&
                !String.IsNullOrEmpty(outFileNames) && !String.IsNullOrEmpty(outFileAddresses);
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
        public ICommand runAppCmd {
            get {
                return _runAppCmd ?? (
                  _runAppCmd = new RelayCommand(
                      onRunApp, canRunApp));
            }
        }
        #endregion // Commands
    }
}
