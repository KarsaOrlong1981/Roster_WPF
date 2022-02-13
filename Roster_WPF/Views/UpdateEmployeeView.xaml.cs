using Roster_WPF.Models;
using Roster_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Roster_WPF.Views
{
    /// <summary>
    /// Interaktionslogik für UpdateEmployeeView.xaml
    /// </summary>
    public partial class UpdateEmployeeView : Window
    {
        UpdateEmployeeViewModel vm;
        public UpdateEmployeeView()
        {
            InitializeComponent();
            vm = new UpdateEmployeeViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            AddToDatabase();
        }
        private async void AddToDatabase()
        {
            var db = App.Db;
            await db.DeleteAllItems<Employee>();
            foreach (var item in vm.EmployeeList)
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
                    OperatingTime = item.OperatingTime,
                });
            }

        }
    }
}
