using HospitalBooking.Models;
using HospitalBooking.Services;
using HospitalBooking.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HospitalBooking.ViewModels
{
    public class RegistrationPageViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; private set; }
        public List<Gender> GenderList { get; set; }
        public List<City> CityList { get; set; }

        public RegistrationPageViewModel()
        {
            GenderList = GetGender().OrderBy(a => a.GenderValue).ToList();
            CityList = GetCity().OrderBy(b => b.Cityname).ToList();
            RegisterCommand = new Command
            (async () => await Register());
        }

        public List<Gender> GetGender()
        {
            var gender = new List<Gender>()
            {
                new Gender()
                {
                    Id = 1,
                    GenderValue = "Male"
                },

                new Gender()
                {
                    Id = 2,
                    GenderValue = "Female"
                }
            };

            return gender;
        }

        public List<City> GetCity()
        {
            var city = new List<City>()
            {
                new City()
                {
                    Id = 1,
                    Cityname = "Taguig City"
                },

                new City()
                {
                    Id = 2,
                    Cityname = "Paranaque City"
                },

                new City()
                {
                    Id = 3,
                    Cityname = "Pasay City"
                },

                new City()
                {
                    Id = 4,
                    Cityname = "Makati City"
                },

                new City()
                {
                    Id = 5,
                    Cityname = "Muntinlupa City"
                },

                new City()
                {
                    Id = 6,
                    Cityname = "San Juan City"
                },

                new City()
                {
                    Id = 7,
                    Cityname = "Mandaluyong City"
                },

                new City()
                {
                    Id = 8,
                    Cityname = "Quezon City"
                },

                new City()
                {
                    Id = 9,
                    Cityname = "Navotas City"
                },

                new City()
                {
                    Id = 10,
                    Cityname = "Pasig City"
                },

                new City()
                {
                    Id = 11,
                    Cityname = "Marikina City"
                }
            };

            return city;
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

        string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }

        string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
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

        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private City _location;
        public City Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public async Task Register()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("No Internet", "You are not connected to internet", "Ok");
            }
            else
            {
                var response = await ApiServices.ServiceClientInstance.RegisterUser(Username, Password, Firstname, Lastname, Age, Gender.GenderValue.ToString(), Location.Cityname.ToString());

                if (response == true)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "User Created Sucessfully", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failed", "User Creation Failed", "Ok");
                }
            }
        }
    }
}
