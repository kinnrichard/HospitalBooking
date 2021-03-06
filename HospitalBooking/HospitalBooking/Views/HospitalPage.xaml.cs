using HospitalBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HospitalBooking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class HospitalPage : ContentPage
    {
        public HospitalPage(string location)
        {
            InitializeComponent();
            BindingContext = new HospitalPageViewModel(location);
            //BindingContext = new MainPageViewModel();
            NavigationPage.SetHasBackButton(this, false);
        }
    }   
}