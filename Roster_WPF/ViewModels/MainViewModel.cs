using Roster_WPF.Views;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Roster_WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }//To close window CloseAction();
        #region ICommands

        public ICommand EmployeeViewCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand TempFil_1Command { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }

        #endregion // ICommands

        #region INotyfyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion //INotifyPropertyChanged

        #region Constructors

        public MainViewModel()
        {
            EmployeeViewCommand = new RelayCommand(CallEmployeeView);
            AddEmployeeCommand = new RelayCommand(CallAddEmployee);
            TempFil_1Command = new RelayCommand(CallFil_1);
            UpdateEmployeeCommand = new RelayCommand(CallUpdateEmployee);
        }
        #endregion // Constructors

        #region Fuctions

        private void CallEmployeeView(object parameter)
        {
            EmployeeView call = new EmployeeView();
            call.Show();
          
        }
        private void CallAddEmployee(object parameter)
        {
            AddEmployeesView call = new AddEmployeesView();
            call.Show();
          
        }
        private void CallFil_1(object parameter)
        {
           
        }
        private void CallUpdateEmployee(object parameter)
        {
           UpdateEmployeeView call = new UpdateEmployeeView();
            call.Show();
        }
        #endregion // Fuctions

    }
}
