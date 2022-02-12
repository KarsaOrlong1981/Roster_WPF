using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roster_WPF.ViewModels
{
    public class UpdateEmployeeViewModel : EmployeeCollection, INotifyPropertyChanged
    {
        #region INotyfyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;
        protected override void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion //INotifyPropertyChanged

        public Action CloseAction { get; set; }//To close window CloseAction();
    }
}
