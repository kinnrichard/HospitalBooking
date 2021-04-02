using HospitalBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HospitalBooking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentPage : ContentPage
    {
        public AppointmentPage(Guid id)
        {
            InitializeComponent();
            BindingContext = new AppointmentPageViewModel(id);
            //BindingContext = new MainPageViewModel();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}