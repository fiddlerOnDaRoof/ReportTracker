using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ReportTracker.Model
{
    public class RequestModel:ViewModelBase
    {
        public RequestModel(RequestType _request, DateTime _timeRequested, string _details)
        {
            Request = _request;
            TimeRequested = _timeRequested;
            Details = _details;

        }
        public DateTime TimeRequested { get; set; }
        public RequestType Request { get; set; }
        public string Details { get; set; }
        public bool Completed
        {
            get
            {
                return m_completed;
            }
            set
            {
                m_completed = value;
                RaisePropertyChanged();
            }
        }



        private bool m_completed;
    }
}
public enum RequestType
{
    EMERGENCY,
    AID,
}
