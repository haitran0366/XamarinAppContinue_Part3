using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAppContinue_Part3.Services;
using XamarinAppContinue_Part3.View;

namespace XamarinAppContinue_Part3.ViewModel
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command cmdLogin { get; set; }
        public Command cmdCreateAccount { get; set; }
        public Command cmdForgotPassword { get; set; }
        public Command cmdSetting { get; set; }

        //ILoginService ilog = DependencyService.Get<ILoginService>(); //todo

        public LoginPageViewModel()
        {
            cmdLogin = new Command(gotoMainPage);
            cmdCreateAccount = new Command(gotoCreateAccount);
            cmdForgotPassword = new Command(gotoForgotPassword);
            cmdSetting = new Command(gotoSetting);
        }

        private void gotoSetting(object obj)
        {
            TurnLoginMessage = true;
            //App.Current.MainPage.Navigation.PushAsync(new SettingPage());
            LoginMessage = "Setting function will be done in next video.";
        }

        private void gotoForgotPassword(object obj)
        {
            TurnLoginMessage = true;
            //App.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());//todo
            LoginMessage = "Forgot password function will be done in next video.";
        }

        private void gotoCreateAccount(object obj)
        {
            Application.Current.MainPage = new NavigationPage(new CreateAccountPage());

        }

        private IUserService ius = new UserService();
        private async void gotoMainPage(object obj)
        {
            var t = await Task.Run(() => ius.checkLogin(UserName, Password));

            //bool isValidLogin = await ius.checkLogin(UserName, Password);

            if (t)
            {
                App.Current.MainPage = new MainPage();
            }
            else
            {
                TurnLoginMessage = true;
                LoginMessage = "A ha 2";
            }

            //TurnLoginMessage = true;
            //LoginMessage = "gotoMainPage function will be done in next video.";

        }
        //----------------------------------
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string loginMessage;
        public string LoginMessage
        {
            get { return loginMessage; }
            set
            {
                loginMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoginMessage"));
            }
        }

        private bool turnLoginMessage = false;
        public bool TurnLoginMessage
        {
            get { return turnLoginMessage; }
            set
            {
                turnLoginMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnLoginMessage"));
            }
        }
    }
}
