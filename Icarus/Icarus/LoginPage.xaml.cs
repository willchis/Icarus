using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Icarus.Models;
using Xamarin.Forms.Xaml;

namespace Icarus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Title = "Login";
            var vm = new LoginViewModel();
            BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += (text) =>
            {
                DisplayAlert("Error", text, "OK");
            };

            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
    }
}