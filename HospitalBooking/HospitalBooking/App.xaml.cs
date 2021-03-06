using HospitalBooking.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HospitalBooking
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "Expander_Experimental"
            });
            MainPage = new NavigationPage(new LoginPage());

            //NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
