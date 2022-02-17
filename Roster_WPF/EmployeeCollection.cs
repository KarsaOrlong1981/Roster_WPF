using Roster_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Roster_WPF
{
    public class EmployeeCollection : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
       
        private static ObservableCollection<Employee> _emplyoee;
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        public ObservableCollection<Employee> EmployeeList
        {
            get { return _emplyoee; }
            set
            {
                if (value != _emplyoee)
                {
                    _emplyoee = value;
                    NotifyPropertyChanged();
                }

            }
        }
        private void LoadAllFromDb()
        {
            var db = App.Db;
            for (int i = 0; i < db.GetAllItemsAsync().Result.Count; i++)
            {
                int id = db.GetAllItemsAsync().Result[i].Id;
                Employee person = db.GetItemAsync(id).Result;
                EmployeeList.Add(person);
            }
        }
        public EmployeeCollection()
        {
            EmployeeList = new ObservableCollection<Employee>();
            //EmployeeList = GetTemplateUserList();
             LoadAllFromDb();
        }
        public ObservableCollection<Employee> GetTemplateUserList()
        {
            ObservableCollection<Employee> _employeeList;
            
            _employeeList = new ObservableCollection<Employee>
            {
                new Employee{Id = 1,Name="Raj", HoursNow = 30.5, HoursMonth = 170, Place = "Morbach", MissingHours = 12, PhoneNumber = "0174/5436273", Status = 1, LastName = "Singbour", Color = "Red"},
                 new Employee{Id = 2,Name="Mark", HoursNow = 25, HoursMonth = 200, MissingHours = 6, PhoneNumber = "0176/7543647", Status = 1, LastName = "Schneider", Color = "Blue"},
                  new Employee{Id = 3,Name="Rainer", HoursNow = 33, HoursMonth = 120, Color = "Green", MissingHours = 20, PhoneNumber = "0173/5467893", Status = 3, LastName = "Ringweiler", HealthInsuranceCert_End = "22.06.2022", HealthInsuranceCert_Start = "29.06.2022"},
                   new Employee{Id = 4,Name="Sandra", HoursNow = 30.5, Place = "Morbach", HoursMonth = 180, Color = "Black", MissingHours = 10, PhoneNumber = "0174/5266612", Status = 2, LastName = "Müller", HolidayStart = "01.06.2022", HolidayEnd = "15.06.2022" }
            };
            return _employeeList;
        }
        private class Updater : ICommand
        {
            EmployeeCollection em;
           
            public Updater()
            {
               
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
               
            }
           
        }
    }
}
