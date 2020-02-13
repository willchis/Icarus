using Icarus.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icarus
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }
        public static GenerationMixManager GenerationMixManager { get; private set;}

        public App()
        {
            GenerationMixManager = new GenerationMixManager(new RestService());
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            MainPage = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Main Page" },
                Detail = new NavigationPage(new OverviewPage())
            };
        }
        // ...
    }
}
