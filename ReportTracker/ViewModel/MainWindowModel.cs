using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using ReportTracker.Model;
using ReportTracker.Utility;
using ReportTracker.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ReportTracker.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>

    public class MainWindowModel : ViewModelBase
    {
        private string m_test;
        private ContentViewModel m_contentViewModel;
        DashboardViewModel m_dashboard;
        ObservableCollection<PatientModel> m_patients;
        private const string REQUEST_FOLDER = "\\\\LAPTOP-MUPHT9FD\\Users\\micha\\Documents\\LAN_Files";
        //"\\\\LAPTOP-MUPHT9FD\\Users\\micha\\Documents\\LAN_Files"
        private int doubleTick = 0;
        public async void FileChanged(object _sender, EventArgs _args)
        {
            DirectoryInfo d = new DirectoryInfo(REQUEST_FOLDER);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("John_Smith_Request.txt"); //Getting Text files
            
            foreach (FileInfo file in Files)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        RequestType type = RequestType.EMERGENCY;
                        string name = values[0];
                        if (values[1].Equals("Aid")){
                            type = RequestType.AID;
                        }if (values[1].Equals("Emergency"))
                        {
                            type = RequestType.EMERGENCY;
                        }

                        string details = values[2];

                        if (type.Equals(RequestType.EMERGENCY))
                        {
                            OpenView(name, details);
                        }
                        else
                        {
                            MessageQueue.Enqueue($"{name} would like {details}!");
                        }
                        foreach (PatientModel p in m_patients)
                        {
                            if (p.PatientName.Equals(name))
                            {
                                await Application.Current.Dispatcher.BeginInvoke(
                                new Action(() =>
                                {
                                    bool repeat = false;
                                    foreach (RequestModel reqMod in p.Requests)
                                    {
                                        if (reqMod.Details.Equals(details) && (reqMod.TimeRequested-DateTime.Now).TotalSeconds<3 && reqMod.Request.Equals(type))
                                        {
                                            repeat = true;
                                        }
                                    }
                                    if (!repeat)
                                    {
                                        p.AddRequest(new RequestModel(type, DateTime.Now, details));
                                    }

                                }));
                                
                            }
                        }
                    }
                    
                }
            }

            

        }
        public MainWindowModel()
        {

            FileWatcher fileWatcher = new FileWatcher();
            fileWatcher.Watch(REQUEST_FOLDER, FileChanged);

            m_patients = new ObservableCollection<PatientModel>();
            AddPatient(new PatientModel("John Smith"));
            AddPatient(new PatientModel("Sam Shah"));
            AddPatient(new PatientModel("Michael Zon"));
            m_patients[1].CreateDefaultRequests();
            m_patients[2].CreateDefaultRequests();
            MainDrawerViewModel = new MainDrawerViewModel(m_patients);
            MainDrawerViewModel.ChangeDashboardEvent += ChangeDashboardEventHandler;
            m_dashboard = new DashboardViewModel(m_patients);
            ContentViewModel = m_dashboard;
            MessageQueue = new SnackbarMessageQueue();



        }
        public void OpenView(string _patientName, string _details)
        {
            Application.Current.Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    var view = new EmergencyPatientView
                    {
                        DataContext = new EmergencyViewModel($"{_patientName} is having an emergency! He is having {_details}")
                    };

                    DialogHost.Show(view, "RootDialog");

                }));
        }
        private void ChangeDashboardEventHandler(object _sender, EventArgs _args)
        {
            ContentViewModel = m_dashboard;
            IsDrawerOpen = false;
        }
        public MainDrawerViewModel MainDrawerViewModel { get; }
        public ContentViewModel ContentViewModel
        {
            get
            {
                return m_contentViewModel;
            }
            set
            {
                m_contentViewModel = value;
                RaisePropertyChanged();
            }
        }
        public void AddPatient(PatientModel p)
        {
            m_patients.Add(p);
            p.ChangePatientEvent += ChangePatientEventHandler;
        }

        public bool IsDrawerOpen
        {
            get { return m_isDrawerOpen; }
            set
            {
                m_isDrawerOpen = value;
                RaisePropertyChanged();
            }
        }
        public SnackbarMessageQueue MessageQueue
        {
            get; set;
        }

        private bool m_isDrawerOpen;
        private void ChangePatientEventHandler(object _sender, PatientEventArgs _args)
        {
            ContentViewModel = new PatientScreenViewModel(_args.Patient);
            IsDrawerOpen = false;
        }

    }
}