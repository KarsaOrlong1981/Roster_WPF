using Roster_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roster_WPF.ViewModels
{
    public class EmployeeViewModel : EmployeeCollection, INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }//To close window CloseAction();
        #region INotyfyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;
        protected override void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion //INotifyPropertyChanged
        #region Constructors
        public EmployeeViewModel()
        {
           

        }
        #endregion // Constructors
        #region Fuctions
        
        #endregion // Fuctions
    }
}
