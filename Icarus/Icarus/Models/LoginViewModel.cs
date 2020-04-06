using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Icarus.Models
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            var overview = new NavigationPage(new OverviewPage());
            NavigationPage.SetHasBackButton(overview, false);

            MasterDetailPage fpm = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Menu" },
                Detail = overview 
            };
            
            Application.Current.MainPage = fpm;
            
            // POST to API
            //if (email != "macoratti@yahoo.com" || password != "secret")
            //{
              //  DisplayInvalidLoginPrompt();
            //}
        }
    }
}