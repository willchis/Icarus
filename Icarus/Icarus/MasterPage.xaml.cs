using Icarus.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icarus
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			InitializeComponent();
			BindingContext = new MasterViewModel();
		}
	}
}