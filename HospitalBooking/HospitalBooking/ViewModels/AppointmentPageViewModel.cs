using HospitalBooking.Models;
using HospitalBooking.Services;
using HospitalBooking.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HospitalBooking.ViewModels
{
    public class AppointmentPageViewModel : BaseViewModel
    {
        public ICommand BookappointmentCommand { get; private set; }
        public string MinimumDate = DateTime.Now.ToString("MM/dd/yyyy");
        public string MaximumDate = DateTime.Now.AddYears(2).ToString("MM/dd/yyyy");

        ObservableCollection<Hospital> _hospitalList;
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

        string _appointmentdate;
        public string AppointmentDate
        {
            get { return _appointmentdate; }
            set
            {
                _appointmentdate = value;
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

        string _patientusername;
        public string PatientUsername
        {
            get { return _patientusername; }
            set
            {
                _patientusername = value;
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

        Guid _hospitalid;
        public Guid HospitalId
        {
            get { return _hospitalid; }
            set
            {
                _hospitalid = value;
                OnPropertyChanged();
            }
        }

        private Hospital _hospitalname;
        public Hospital HospitalName
        {
            get { return _hospitalname; }
            set
            {
                _hospitalname = value;
                OnPropertyChanged();
                GetHospitalInfo(HospitalName.Hospitalname.ToString());
            }
        }

        string _hospitallocation;
        public string HospitalLocation
        {
            get { return _hospitallocation; }
            set
            {
                _hospitallocation = value;
                OnPropertyChanged();
            }
        }

        private async void GetPatientInfo()
        {
            var response = await ApiServices.ServiceClientInstance.GetPatientInfo(PatientId);
            if (response != null)
            {
                PatientUsername = response.Username;
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

        private async void GetHospitalInfo(string hospitalname)
        {
            var response = await ApiServices.ServiceClientInstance.GetHospitalInfo(hospitalname);
            if (response != null)
            {
                HospitalId = response.Id;
                HospitalLocation = response.Location.ToString();
            }
        }

        private async Task BookAppointment()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("No Internet", "You are not connected to internet", "Ok");             
            }
            else
            {
                var response = await ApiServices.ServiceClientInstance.BookAppointment(
                    AppointmentName, 
                    AppointmentDescription, 
                    AppointmentDate, 
                    PatientId, 
                    PatientName, 
                    PatientLocation, 
                    PatientAge,
                    PatientGender,
                    HospitalId,
                    HospitalName.Hospitalname.ToString(),
                    HospitalLocation
                    );

                if (response == true)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "You book at " + HospitalName.Hospitalname.ToString() + " on " + AppointmentDate.ToString() , "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new MainPage(PatientId,PatientUsername,PatientLocation));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failed", "Booking Failed", "Ok");
                }
            }
        }

        public AppointmentPageViewModel(Guid id)
        {
            PatientId = id;
            GetPatientInfo();

            BookappointmentCommand = new Command
            (async () => await BookAppointment());
        }

        public AppointmentPageViewModel()
        {

        }
    }
}
