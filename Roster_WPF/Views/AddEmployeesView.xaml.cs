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
    /// Interaktionslogik für AddEmployeesView.xaml
    /// </summary>
    public partial class AddEmployeesView : Window
    {
        public AddEmployeesView()
        {
            InitializeComponent();
            AddEmployeeViewModel vm = new AddEmployeeViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
