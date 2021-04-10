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
        public ICommand AppointmentCommand { get; private set; }
        public ICommand MyAppointmentCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public ICommand SupportCommand { get; private set; }
        public ICommand NotificationCommand { get; private set; }

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

        int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            
        }

        public MainPageViewModel(Guid id,string username, string location)
        {
            Id = id;
            Username = username;
            Location = location;    

            HospitalCommand = new Command
            (async () => await App.Current.MainPage.Navigation.PushAsync(new HospitalPage(Location)));

            AppointmentCommand = new Command
           (async () => await App.Current.MainPage.Navigation.PushAsync(new AppointmentPage(Id)));

            MyAppointmentCommand = new Command
           (async () => await App.Current.MainPage.Navigation.PushAsync(new MyAppointmentPage(Id)));

            SettingsCommand = new Command
           (async () => await App.Current.MainPage.Navigation.PushAsync(new SettingsPage()));

            SupportCommand = new Command
           (async () => await App.Current.MainPage.Navigation.PushAsync(new SupportPage()));

            NotificationCommand = new Command
          (async () => await App.Current.MainPage.Navigation.PushAsync(new NotificationPage()));


        }
    }
}
