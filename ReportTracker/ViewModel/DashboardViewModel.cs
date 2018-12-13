using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReportTracker.Model;

namespace ReportTracker.ViewModel
{
    public class DashboardViewModel:ContentViewModel
    {
        
        public DashboardViewModel(ObservableCollection<PatientModel> _patients)
        {
            Patients = _patients;
            
        }
        
        public ObservableCollection<PatientModel> Patients {get;set;}

        
    }
}
