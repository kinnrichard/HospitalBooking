using HospitalBooking.Models;
using HospitalBooking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HospitalBooking.ViewModels
{
    public class MyAppointmentPageViewModel : BindableObject
    {
        ObservableCollection<Appointment> _appointmentList;
        public ObservableCollection<Appointment> AppointmentList
        {
            get { return _appointmentList; }
            set
            {
                _appointmentList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<AppointmentDetails> _appointmentListDetails;
        public ObservableCollection<AppointmentDetails> AppointmentListDetails
        {
            get { return _appointmentListDetails; }
            set
            {
                _appointmentListDetails = value;
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

        
        private async void GetAppointment()
        {
            var response = await ApiServices.ServiceClientInstance.GetAppointment(PatientId);
            AppointmentList = new ObservableCollection<Appointment>(response);
        }

        private async void GetAppointmentDetails()
        {
            var response = await ApiServices.ServiceClientInstance.GetAppointmentDetails(PatientId);
            AppointmentListDetails = new ObservableCollection<AppointmentDetails>(response);
        }

        public MyAppointmentPageViewModel(Guid id)
        {
            PatientId = id;
            GetAppointment();
            GetAppointmentDetails();
        } 

    }
}
