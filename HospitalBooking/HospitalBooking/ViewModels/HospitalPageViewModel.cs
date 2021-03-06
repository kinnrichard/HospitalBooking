using HospitalBooking.Models;
using HospitalBooking.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HospitalBooking.ViewModels
{
    public class HospitalPageViewModel : BindableObject
    {
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

        string _location;
        public string LocationName
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        private async void GetHostpitals()
        {
            var response = await ApiServices.ServiceClientInstance.GetHospitalList(LocationName);
            HospitalList = new ObservableCollection<Hospital>(response);
        }
        public HospitalPageViewModel(string location)
        {
            LocationName = location;
            GetHostpitals();
        }
    }
}
