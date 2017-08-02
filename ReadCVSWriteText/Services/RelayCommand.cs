using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadCVSWriteText.Services {
    /// <summary>
    /// Auto rechecks "can execute"
    /// </summary>
    public class RelayCommand : ICommand {

        #region Fields
        readonly Action _execute;
        readonly Func<bool> _canExecute;
        #endregion // Fields

        #region Constructors
        public RelayCommand(Action execute) : this(execute, null) {

        }

        public RelayCommand(Action execute, Func<bool> canExecute) {

            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand members
        public bool CanExecute(object param) {

            return _canExecute == null ? true : _canExecute();
        }

        public event EventHandler CanExecuteChanged {

            add {
                CommandManager.RequerySuggested += value;
            }

            remove {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object param) {

            _execute();
        }
        #endregion // ICommand members
    }

    /// <summary>
    /// Auto rechecks "can execute". For commands that take a parameter
    /// </summary>
    /// <typeparam name="ParType">The type command parameter</typeparam>
    public class RelayCommand<ParType> : ICommand {

        #region Fields
        readonly Action<ParType> _execute;
        readonly Func<ParType, bool> _canExecute;
        #endregion // Fields

        #region Constructors
        public RelayCommand(Action<ParType> execute) : this(execute, null) {

        }

        public RelayCommand(Action<ParType> execute, Func<ParType, bool> canExecute) {

            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand members
        public bool CanExecute(object param) {

            return _canExecute == null ? true : _canExecute((ParType)param);
        }

        public event EventHandler CanExecuteChanged {

            add {
                CommandManager.RequerySuggested += value;
            }

            remove {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object param) {

            _execute((ParType)param);
        }
        #endregion // ICommand members
    }
}
