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
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage(Guid Id)
        {
            InitializeComponent();
            BindingContext = new NotificationPageViewModel(Id);
            //BindingContext = new MainPageViewModel();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}