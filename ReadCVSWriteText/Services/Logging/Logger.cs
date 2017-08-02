using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.Services.Logging {
    /// <summary>
    /// Defines values for categories used by ReadCVSWriteText.Services.Logging.Logger
    /// </summary>
    public enum Category {
        Info        = 0,
        Debug       = 1,
        Warn        = 2,
        Exception   = 3
    }

    /// <summary>
    /// Defines values for priorities used by ReadCVSWriteText.Services.Logging.Logger
    /// </summary>
    public enum Priority {
        None    = 0,
        Low     = 1,
        Medium  = 2,
        High    = 3
    }
    /// <summary>
    /// Singleton. Not thread safe.
    /// </summary>
    public class Logger {

        #region Constructors
        private Logger() {
            
            // If the log file does not exist, create it
            if(!File.Exists(_log_file)) {

                // No try-catch in Log, this must always work, else, it must
                // show the exception and not be silent
                File.WriteAllText(_log_file, "Log" + Environment.NewLine);
            }
        }
        #endregion // Constructors

        #region Private members
        private String _log_file = "log.txt";
        private static Logger _instance;
        #endregion // Private members

        #region Public members
        public ObservableCollection<String> logs { get; set; } = new ObservableCollection<string>();
        public static Logger instance {
            get {
                if (_instance == null)
                    _instance = new Logger();

                return _instance;
            }
        }

        public void log(String message, Category category, Priority priority) {

            String msg = category.ToString("D") + " | " + priority.ToString("D")
                + " | " + message + Environment.NewLine;

            // No try-catch in Log, this must always work, else, it must
            // show the exception and not be silent
            File.AppendAllText(_log_file, msg);

            // Add to collection
            logs.Add(msg);
        }
        #endregion // Public members
    }
}
