using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Icarus.Models
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action<string> DisplayInvalidLoginPrompt;

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

        public async void OnSubmit()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                string sUrl = "https://whiteheart.on.teamlewis.com/api/authenticate/authenticate";
                string sContentType = "application/json";

                JObject json = new JObject();
                json.Add("username", email);
                json.Add("password", password);

                HttpClient client = new HttpClient();
                var response = await client.PostAsync(sUrl, new StringContent(json.ToString(), Encoding.UTF8, sContentType));
                
                    // response of post here
                if (!response.IsSuccessStatusCode)
                {
                    DisplayInvalidLoginPrompt("An error occurred:" + response.StatusCode);
                    return;
                }

                var content = response.Content.ReadAsStringAsync().Result;

                var user = JsonConvert.DeserializeObject<UserDto>(content);
                if (user != null && !string.IsNullOrWhiteSpace(user.Token))
                {
                    var overview = new NavigationPage(new OverviewPage());
                    NavigationPage.SetHasBackButton(overview, false);

                    MasterDetailPage fpm = new MasterDetailPage()
                    {
                        Master = new MasterPage() { Title = "Menu", },
                        Detail = overview
                    };

                    Application.Current.MainPage = fpm;
                } else
                {
                    DisplayInvalidLoginPrompt("Invalid login, please try again.");
                }
                
            } else
            {
                DisplayInvalidLoginPrompt("No internet connection available!");
            }
            
        }
    }
}