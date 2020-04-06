using System.Windows.Input;
using Xamarin.Forms;

namespace Icarus.Models
{
	public class MasterViewModel
	{
		public ICommand NavigationCommand
		{
			get
			{
				return new Command((value) =>
				{
					// COMMENT: This is just quick demo code. Please don't put this in a production app.
					var mdp = (Application.Current.MainPage as MasterDetailPage);
					var navPage = mdp.Detail as NavigationPage;

					// Hide the Master page
					mdp.IsPresented = false;
					Page pageToNavTo = new OverviewPage();

					switch (value)
					{
						case "1":
							navPage.PopToRootAsync();
							break;
						case "2":
							pageToNavTo = new GenerationStatsPage();
							break;
						case "3":
							pageToNavTo = new NotesPage();
							break;
					}
					NavigationPage.SetHasBackButton(pageToNavTo, false);
					navPage.PushAsync(pageToNavTo, false);

				});
			}
		}
	}
}
