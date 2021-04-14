using HospitalBooking.Models;
using HospitalBooking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HospitalBooking.ViewModels
{
    public class NotificationPageViewModel : BindableObject
    {
        ObservableCollection<Notification> _notificationList;
        public ObservableCollection<Notification> NotificationList
        {
            get { return _notificationList; }
            set
            {
                _notificationList = value;
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

        private async void GetNotification()
        {
            var response = await ApiServices.ServiceClientInstance.GetNotification(PatientId);
            NotificationList = new ObservableCollection<Notification>(response);
        }

        public NotificationPageViewModel(Guid Id)
        {
            PatientId = Id;
            GetNotification();
        }
    }
}
