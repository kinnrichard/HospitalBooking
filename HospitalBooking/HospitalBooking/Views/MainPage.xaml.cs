using HospitalBooking.Models;
using HospitalBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HospitalBooking
{
    public partial class MainPage : ContentPage
    {   
        public MainPage(Guid id,string username, string location)
        {

            InitializeComponent();
            BindingContext = new MainPageViewModel(id,username,location);
            //BindingContext = new MainPageViewModel();
            NavigationPage.SetHasBackButton(this, false);


        }
    }
}
