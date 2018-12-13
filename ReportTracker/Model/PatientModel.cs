using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportTracker.Model
{
    public class PatientModel:ViewModelBase
    {
        private string m_patientName;

        public PatientModel(string _patientName)
        {
            PatientName = _patientName;
            Requests = new ObservableCollection<RequestModel>();
            
        }

        public void CreateDefaultRequests()
        {
            AddRequest(new RequestModel(RequestType.AID, DateTime.Now, "bathroom"));
            AddRequest(new RequestModel(RequestType.AID, DateTime.Now, "bathroom"));
            AddRequest(new RequestModel(RequestType.AID, DateTime.Now, "meal"));
            AddRequest(new RequestModel(RequestType.AID, DateTime.Now, "water"));
        }

        public void AddRequest(RequestModel _request)
        {
            Requests.Add(_request);
        }

        public string PatientName
        {
            get
            {
                return m_patientName;
            }
            set
            {
                m_patientName = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RequestModel> Requests { get; set; }

        public ObservableCollection<RequestModel> MainScreenRequests {
            get
            {
                ObservableCollection<RequestModel> retRequests = new ObservableCollection<RequestModel>();
                foreach (RequestModel r in Requests)
                {
                    if (!r.Completed)
                    {
                        retRequests.Add(r);
                    }
                }
                return retRequests;
            }
        }

        public void RaiseChangePatientScreenCommand()
        {
            ChangePatientEvent?.Invoke(this, new PatientEventArgs(this));
        }
        
        public event EventHandler<PatientEventArgs> ChangePatientEvent;
    }
    public class PatientEventArgs : EventArgs
    {
        public PatientEventArgs(PatientModel _p)
        {
            Patient = _p;
        }
        public PatientModel Patient { get; set; }
    } 
}
