using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Icarus.Models;

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

            listView.ItemsSource = await App.GenerationMixManager.GetTasksAsync();

        }
    }
}