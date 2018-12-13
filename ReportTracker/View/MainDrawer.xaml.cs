using ReportTracker.Model;
using ReportTracker.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportTracker.View
{
    /// <summary>
    /// Interaction logic for MainDrawer.xaml
    /// </summary>
    public partial class MainDrawer : UserControl
    {
        public MainDrawer()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            PatientModel item = e.NewValue as PatientModel;
            if (item != null)
            {
                item.RaiseChangePatientScreenCommand();
            }
            if (e.NewValue == DashboardItem)
            { 
                var vm = DataContext as MainDrawerViewModel;
                vm.RaiseChangeDashboardCommand();
            }

        }
    }
}
