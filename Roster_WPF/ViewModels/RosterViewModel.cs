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
       
        public RosterViewModel()
        {
            MondayList = new ObservableCollection<Roster>();
            TuesdayList = new ObservableCollection<Roster>();
            WednesdayList = new ObservableCollection<Roster>();
            ThursdayList = new ObservableCollection<Roster>();
            FridayList = new ObservableCollection<Roster>();
            SaturdayList = new ObservableCollection<Roster>();
            
            GetMondayList();
        }
       
        #region Day Lists
        private void GetMondayList()
        {
            foreach (var item in EmployeeList)
            {
                Roster ro = new Roster();
                ExamineStatus(ro, item);
                
                MondayList.Add(ro);
            }
        }
        #endregion // Day Lists
        #region Scrutinies
        private void ExamineStatus(Roster ro, Employee propertys)
        {
            
            
                switch (propertys.Status)
                {
                    case 1: ExamineOperatingTime(ro, propertys) ; break;
                    case 2:  break; //Status 2 = Urlaub, prüfen von - bis und die und nur Name anzeigen und alle felder auf Hidden setzen
                    case 3:  break; //Status 3 = Krank, prüfen von - bis und die und nur Name anzeigen und alle felder auf Hidden setzen
                    default : break;//nur name anzeigen und alle felder auf Hidden setzen
                }
            
        }
        private void ExamineOperatingTime(Roster ro, Employee propertys)
        {
           
            
                switch (propertys.OperatingTime)
                {
                    case 1: SwitchEarly(ro, propertys); break;
                    case 2: SwitchLate(ro, propertys); break;
                    case 3: break; // Switch Nigth
                    case 4:; break; // zeit = früh oder Nacht / überprüfen wieviele leute insgesamt für die verschiedenen Schichten
                                    // benötigt werden und abgleichen wer die schichten je nach operatingTime belegen kann
                    case 5: break; // zeit = spät oder Nacht / überprüfen wieviele leute insgesamt für die verschiedenen Schichten
                                   // benötigt werden und abgleichen wer die schichten je nach operatingTime belegen kann
                    case 6: break; // zeit = früh oder Spät / überprüfen wieviele leute insgesamt für die verschiedenen Schichten
                                   // benötigt werden und abgleichen wer die schichten je nach operatingTime belegen kann
                    case 7: break; // zeit = früh,Spät,Nacht / überprüfen wieviele leute insgesamt für die verschiedenen Schichten
                                   // benötigt werden und abgleichen wer die schichten je nach operatingTime belegen kann
                    default: break;
                }
            
        }
        
        #endregion //Scrutinies
        
        private Roster SwitchEarly(Roster ro, Employee propertys)
        {
            ro.Name = propertys.Name;
            ro.LastName = propertys.LastName;
            ro.Color = propertys.Color;
            ro.Is_15_OClock = Visibility.Hidden;
            ro.Is_16_OClock = Visibility.Hidden;
            ro.Is_17_OClock = Visibility.Hidden;
            ro.Is_18_OClock = Visibility.Hidden;
            ro.Is_19_OClock = Visibility.Hidden;
            ro.Is_20_OClock = Visibility.Hidden;
            ro.Is_21_OClock = Visibility.Hidden;
            ro.Is_22_OClock = Visibility.Hidden;
            ro.Is_23_OClock = Visibility.Hidden;
            ro.Is_24_OClock = Visibility.Hidden;
            return ro;
        }
        private Roster SwitchLate(Roster ro, Employee propertys)
        {
            ro.Name = propertys.Name;
            ro.LastName = propertys.LastName;
            ro.Color = propertys.Color;
            

            ro.Is_6_OClock = Visibility.Hidden;
            ro.Is_7_OClock = Visibility.Hidden;
            ro.Is_8_OClock = Visibility.Hidden;
            ro.Is_9_OClock = Visibility.Hidden;
            ro.Is_10_OClock = Visibility.Hidden;
            ro.Is_11_OClock = Visibility.Hidden;
            ro.Is_12_OClock = Visibility.Hidden;
            ro.Is_13_OClock = Visibility.Hidden;

            ro.Is_23_OClock = Visibility.Hidden;
            ro.Is_24_OClock = Visibility.Hidden;
            return ro;
        }
        /*private EmployeePropertys SwitchNigth(EmployeePropertys propertys, Employee employee)
        {
            propertys.FirstName = employee.Name;
            propertys.LastName = employee.LastName;
            propertys.Color = employee.Color;
            
            propertys.Is_7_OClock = Visibility.Hidden;
            propertys.Is_8_OClock = Visibility.Hidden;
            propertys.Is_9_OClock = Visibility.Hidden;
            propertys.Is_10_OClock = Visibility.Hidden;
            propertys.Is_11_OClock = Visibility.Hidden;
            propertys.Is_12_OClock = Visibility.Hidden;
            propertys.Is_13_OClock = Visibility.Hidden;

            propertys.Is_23_OClock = Visibility.Hidden;
            propertys.Is_24_OClock = Visibility.Hidden;
            return propertys;
        }*/

    }
}
