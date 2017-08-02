using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCVSWriteText.ViewModels {
    /// <summary>
    /// Base class for ViewModels
    /// </summary>
    public class BindableVM : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(String property_name) {

            var handler = PropertyChanged;

            if(handler != null) {
                handler(this, new PropertyChangedEventArgs(property_name));
            }
        }
    }
}
