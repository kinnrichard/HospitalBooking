using HospitalBooking.Services;
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
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command
            (async () => await Login());

            RegisterCommand = new Command
             (async () => await App.Current.MainPage.Navigation.PushAsync(new RegistrationPage()));
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

        string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        Guid id;
        public string Username_;
        public string Location_;

        private async Task Login()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("No Internet", "You are not connected to internet.", "Ok");
            }
            else
            {
                var response = await ApiServices.ServiceClientInstance.LoginUser(Username, Password);

                if (response != null)
                {
                    id = response.Id;
                    Username_ = response.Username;
                    Location_ = response.Location;

                    await App.Current.MainPage.Navigation.PushAsync(new MainPage(id, Username_, Location_));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid", "Wrong Username or Password.", "Ok");
                }
            }           
        }
    }
}
