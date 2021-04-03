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
    public partial class MyAppointmentPage : ContentPage
    {
        public MyAppointmentPage(Guid id)
        {
            InitializeComponent();
            BindingContext = new MyAppointmentPageViewModel(id);
            //BindingContext = new MainPageViewModel();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}