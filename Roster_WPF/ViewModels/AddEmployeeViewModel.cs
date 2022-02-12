using Roster_WPF.Models;
using Roster_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Roster_WPF.ViewModels
{
    public class AddEmployeeViewModel : EmployeeCollection, INotifyPropertyChanged
    {
        private int idAdd;
        private string nameAdd, lastNameAdd, phoneNumberAdd;
        SolidColorBrush[] colorBrush;
        #region Propertys
        public Action CloseAction { get; set; }
        public ICommand AddCommand { get; set; }
        public int IdAdd
        {
            get { return idAdd; }
            set
            {
                idAdd = value;
                NotifyPropertyChanged();
            }
        }
        public string PhoneNumberAdd
        {
            get { return phoneNumberAdd; }
            set
            {
                phoneNumberAdd = value;
                NotifyPropertyChanged();
            }
        }
        public string NameAdd
        {
            get { return nameAdd; }
            set { nameAdd = value; NotifyPropertyChanged(); }
        }
        public string LastNameAdd
        {
            get { return lastNameAdd; }
            set { lastNameAdd = value; NotifyPropertyChanged(); }
        }
        #endregion // Propertys
        #region INotyfyPropertyChanged
        public new event PropertyChangedEventHandler PropertyChanged;
        protected override void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion //INotyfyPropertyChanged
        public AddEmployeeViewModel()
        {
            IdAdd = GetNextID();
            AddCommand = new RelayCommand(Add);
        }
        private bool CheckIdExisting()
        {

            bool isIDExists = false;
            foreach (var item in EmployeeList)
            {
                if (item.Id == IdAdd)
                {
                    isIDExists = true;
                    break;
                }
            }
            return isIDExists;
        }
        private int GetNextID()
        {
            int nextID = 1;
            if(EmployeeList.Count != 0)
            {
                nextID = EmployeeList.Count - 1;
                ObservableCollection<Employee> getNextIdList;
                getNextIdList = new ObservableCollection<Employee>(EmployeeList.OrderBy(x => x.Id));
                nextID = getNextIdList[nextID].Id + 1;
            }
          
            return nextID;
        }
        private void Add(object parameter)
        {
            bool isAnyTBEmpty = false;
            bool isIDExists = false;

            if (NameAdd == null || LastNameAdd == null)
            {
                isAnyTBEmpty = true;
            }
            if (isAnyTBEmpty == false)
            {
                if (isIDExists = CheckIdExisting() == false)
                {
                    Employee emp = new Employee();
                    emp.Id = IdAdd;
                    emp.Name = NameAdd;
                    emp.LastName = LastNameAdd;
                    emp.PhoneNumber = PhoneNumberAdd;
                    emp.Color = GetColorName();
                    EmployeeList.Add(emp);
                    CloseAction();
                    GetColorName();
                    AddToDatabase();
                   


                }
                else
                {
                    int nextID = GetNextID();

                    MessageBox.Show("Diese ID Existiert bereits. die nächste Id wäre " + nextID + ".", "Users", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("Es darf kein Feld leer bleiben.", "Users", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
       
        private async void AddToDatabase()
        {
            var db = App.Db;
            await db.DeleteAllItems<Employee>();
            foreach (var item in EmployeeList)
            {
                await db.AddToDBAsync(new Employee
                {
                    Name = item.Name,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    Color = item.Color,
                    HealthInsuranceCert_End = item.HealthInsuranceCert_End,
                    HealthInsuranceCert_Start = item.HealthInsuranceCert_Start,
                    HolidayEnd = item.HolidayEnd,
                    HolidayStart = item.HolidayStart,
                    Id = item.Id,
                    Status = item.Status,
                    HoursMonth = item.HoursMonth,
                    HoursNow = item.HoursNow,
                    MissingHours = item.MissingHours,
                    Layer = item.Layer,
                    Place = item.Place,
                });
            }

        }
        private string GetColorName()
        {
            Random random = new Random();
            string color = string.Empty;
            InitColorBrushList();
            color = colorBrush[(random.Next(0,colorBrush.Length))].Color.ToString();
            
            return color;
        }
        private void InitColorBrushList()
        {
            colorBrush = new SolidColorBrush[] { Brushes.Green, Brushes.Red, Brushes.Pink, Brushes.Peru, Brushes.PowderBlue,
                                                 Brushes.RosyBrown, Brushes.RoyalBlue, Brushes.SaddleBrown, Brushes.Salmon,
                                                 Brushes.SeaGreen, Brushes.Silver, Brushes.SlateBlue, Brushes.SpringGreen, Brushes.SteelBlue,
                                                 Brushes.Tomato, Brushes.Turquoise, Brushes.Violet, Brushes.YellowGreen, Brushes.Blue, Brushes.BurlyWood, Brushes.CadetBlue,
                                                 Brushes.Chocolate, Brushes.Coral, Brushes.CornflowerBlue, Brushes.Crimson, Brushes.Cyan, Brushes.DarkBlue, Brushes.DarkCyan,
                                                 Brushes.DarkGoldenrod, Brushes.DarkGray, Brushes.DarkGreen, Brushes.DarkMagenta, Brushes.DarkOliveGreen, Brushes.DarkOrange,
                                                 Brushes.DarkOrchid, Brushes.DarkRed, Brushes.DarkSalmon, Brushes.DarkSeaGreen, Brushes.DarkTurquoise, Brushes.DeepSkyBlue,
                                                 Brushes.Firebrick, Brushes.ForestGreen, Brushes.IndianRed, Brushes.HotPink, Brushes.Lavender, Brushes.LawnGreen };

        }
    }
}
