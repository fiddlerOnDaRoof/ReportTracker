using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportTracker.Model;

namespace ReportTracker.ViewModel
{
    public class MainDrawerViewModel:ViewModelBase
    {

        public MainDrawerViewModel(ObservableCollection<PatientModel> _patients)
        {
            Patients = _patients;
            
        }
        public void RaiseChangeDashboardCommand()
        {
            ChangeDashboardEvent?.Invoke(this, EventArgs.Empty);
        }

        public ObservableCollection<PatientModel> Patients
        {
            get;
            private set;
        }

        public event EventHandler ChangeDashboardEvent;

    }
}
