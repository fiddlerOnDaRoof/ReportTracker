using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportTracker.ViewModel
{
    public class EmergencyViewModel:ViewModelBase
    {
        private string m_emergencyText;
        public EmergencyViewModel(string _text)
        {
            EmergencyText = _text;
        }
        public string EmergencyText
        {
            get
            {
                return m_emergencyText;
            }
            set
            {
                m_emergencyText = value;
                RaisePropertyChanged();
            }
        }
    }
}
