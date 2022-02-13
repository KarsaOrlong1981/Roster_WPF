using Roster_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Roster_WPF.ViewModels
{
    public class RosterViewModel : EmployeeCollection, INotifyPropertyChanged
    {
        private struct EmployeePropertys
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Color { get; set; }
        }
        public Action CloseAction { get; set; }//To close window CloseAction();
        #region INotyfyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;
        protected override void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion //INotifyPropertyChanged
        #region Week Roster
        private static ObservableCollection<Roster> _mondayList;
        private static ObservableCollection<Roster> _tuesdayList;
        private static ObservableCollection<Roster> _wednesdayList;
        private static ObservableCollection<Roster> _thursdayList;
        private static ObservableCollection<Roster> _fridayList;
        private static ObservableCollection<Roster> _saturdayList;
        public ObservableCollection<Roster> MondayList
        {
            get { return _mondayList; }
            set
            {
                if (value != _mondayList)
                {
                    _mondayList = value;
                    NotifyPropertyChanged();
                }

            }
        }
        public ObservableCollection<Roster> TuesdayList
        {
            get { return _tuesdayList; }
            set
            {
                if (value != _tuesdayList)
                {
                    _tuesdayList = value;
                    NotifyPropertyChanged();
                }

            }
        }
        public ObservableCollection<Roster> WednesdayList
        {
            get { return _wednesdayList; }
            set
            {
                if (value != _wednesdayList)
                {
                    _wednesdayList = value;
                    NotifyPropertyChanged();
                }

            }
        }
        public ObservableCollection<Roster> ThursdayList
        {
            get { return _thursdayList; }
            set
            {
                if (value != _thursdayList)
                {
                    _thursdayList = value;
                    NotifyPropertyChanged();
                }

            }
        }
        public ObservableCollection<Roster> FridayList
        {
            get { return _fridayList; }
            set
            {
                if (value != _fridayList)
                {
                    _fridayList = value;
                    NotifyPropertyChanged();
                }

            }
        }
        public ObservableCollection<Roster> SaturdayList 
        {
            get { return _saturdayList; }
            set
            {
                if (value != _saturdayList)
                {
                    _saturdayList = value;
                    NotifyPropertyChanged();
                }

            }
        }
        #endregion // Week Roster
        private List<EmployeePropertys> list;
        public RosterViewModel()
        {
            MondayList = new ObservableCollection<Roster>();
            TuesdayList = new ObservableCollection<Roster>();
            WednesdayList = new ObservableCollection<Roster>();
            ThursdayList = new ObservableCollection<Roster>();
            FridayList = new ObservableCollection<Roster>();
            SaturdayList = new ObservableCollection<Roster>();
            GetEmployeesName();
            TestRoster ();
        }
        private void TestRoster()
        {
            foreach (var item in list)
            {
                Roster ro = new Roster();
                ro.Color = item.Color;
                ro.Name = item.FirstName;
                ro.LastName = item.LastName;
                ro.Is_6_OClock = Visibility.Visible;
                ro.Is_7_OClock = Visibility.Hidden;
                MondayList.Add(ro);
            }
        }
        private void GetEmployeesName()
        {   
            EmployeePropertys name = new EmployeePropertys();
            list = new List<EmployeePropertys>();
            foreach (var item in EmployeeList)
            {
                name.FirstName = item.Name;
                name.LastName = item.LastName;
                name.Color = item.Color;
                list.Add(name);
            }
        }

    }
}
