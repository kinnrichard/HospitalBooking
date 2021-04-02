using HospitalBooking.Models;
using HospitalBooking.Services;
using HospitalBooking.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HospitalBooking.ViewModels
{
    public class AppointmentPageViewModel : BindableObject
    {
        public ICommand BookappointmentCommand { get; private set; }

        ObservableCollection<Hospital> _hospitalList;
        public string MinimumDate = DateTime.Now.ToString("MM/dd/yyyy");
        public string MaximumDate = DateTime.Now.AddYears(2).ToString("MM/dd/yyyy");
        public ObservableCollection<Hospital> HospitalList
        {
            get { return _hospitalList; }
            set
            {
                _hospitalList = value;
                OnPropertyChanged();
            }
        }

        string _appointmentname;
        public string AppointmentName
        {
            get { return _appointmentname; }
            set
            {
                _appointmentname = value;
                OnPropertyChanged();
            }
        }

        string _appointmentdescription;
        public string AppointmentDescription
        {
            get { return _appointmentdescription; }
            set
            {
                _appointmentdescription = value;
                OnPropertyChanged();
            }
        }

        Guid _patientid;
        public Guid PatientId
        {
            get { return _patientid; }
            set
            {
                _patientid = value;
                OnPropertyChanged();
            }
        }

        string _patientname;
        public string PatientName
        {
            get { return _patientname; }
            set
            {
                _patientname = value;
                OnPropertyChanged();
            }
        }

        string _patientlocation;
        public string PatientLocation
        {
            get { return _patientlocation; }
            set
            {
                _patientlocation = value;
                OnPropertyChanged();
            }
        }

        int _patientage;
        public int PatientAge
        {
            get { return _patientage; }
            set
            {
                _patientage = value;
                OnPropertyChanged();
            }
        }

        string _patientgender;
        public string PatientGender
        {
            get { return _patientgender; }
            set
            {
                _patientgender = value;
                OnPropertyChanged();
            }
        }

        string _hospitalid;
        public string HospitalId
        {
            get { return _hospitalid; }
            set
            {
                _hospitalid = value;
                OnPropertyChanged();
            }
        }

        string _hospitalname;
        public string HospitalName
        {
            get { return _hospitalname; }
            set
            {
                _hospitalname = value;
                OnPropertyChanged();
            }
        }

        private async void GetPatientInfo()
        {
            var response = await ApiServices.ServiceClientInstance.GetPatientInfo(PatientId);
            if (response != null)
            {
                PatientName = response.Lastname + ", " + response.Firstname;
                PatientLocation = response.Location;
                PatientAge = response.Age;
                PatientGender = response.Gender;

                GetHostpitals();
            }
        }

        private async void GetHostpitals()
        {
            var response = await ApiServices.ServiceClientInstance.GetHospitalList(PatientLocation);
            HospitalList = new ObservableCollection<Hospital>(response);
        }

        public AppointmentPageViewModel(Guid id)
        {
            PatientId = id;
            GetPatientInfo();
        }
    }
}
