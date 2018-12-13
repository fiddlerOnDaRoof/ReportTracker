using ReportTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportTracker.ViewModel
{
    public class PatientScreenViewModel:ContentViewModel
    {
        public PatientScreenViewModel(PatientModel _patient)
        {
            Patient = _patient;
        }

        public PatientModel Patient { get; set; }
        
    }
}
