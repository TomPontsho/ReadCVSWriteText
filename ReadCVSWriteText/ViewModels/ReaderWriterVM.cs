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
        private String _inCSVFile = "./Resources/data.cvs";
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
        private String _outFileAddresses = "addresses.tex";
        public String outFileAddresses {
            get { return _outFileAddresses; }
            set {
                if (_outFileAddresses != value) {
                    _outFileAddresses = value;
                    onPropertyChanged(nameof(outFileAddresses));
                }
            }
        }
        private String _readOutCome = "";
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
        private void onSelectInputCSV() {

        }

        private void onSelectOutputDir() {

        }

        private void onRunApp() {

        }
        private bool canRunApp() {

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
