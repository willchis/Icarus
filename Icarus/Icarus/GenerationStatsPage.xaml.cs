using Xamarin.Forms;

namespace Icarus
{
    public partial class GenerationStatsPage : ContentPage
    {
        public GenerationStatsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            activityMonitor.IsVisible = true;

            listView.ItemsSource = await App.GenerationMixManager.GetTasksAsync();
            activityMonitor.IsVisible = false;
        }
    }
}