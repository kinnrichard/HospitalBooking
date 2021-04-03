using HospitalBooking.Models;
using HospitalBooking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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

        public MyAppointmentPageViewModel(Guid id)
        {
            PatientId = id;
            GetAppointment();
        } 

    }
}
