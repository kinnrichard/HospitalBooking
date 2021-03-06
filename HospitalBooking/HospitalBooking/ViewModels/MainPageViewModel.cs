using HospitalBooking.Models;
using HospitalBooking.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HospitalBooking.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand HospitalCommand { get; private set; }
        Guid _id;
        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            
        }

        public MainPageViewModel(Guid id,string usr, string location)
        {
            Id = id;
            Username = usr;
            Location = location;

            HospitalCommand = new Command
            (async () => await App.Current.MainPage.Navigation.PushAsync(new HospitalPage(Location)));

        }
    }
}
