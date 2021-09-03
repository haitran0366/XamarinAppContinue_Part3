using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppContinue_Part3.Services;
using XamarinAppContinue_Part3.View;

namespace XamarinAppContinue_Part3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IUserService, UserService>();
            MainPage = new LoginPage();
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
