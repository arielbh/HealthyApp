using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipesPage: ContentPage
	{
		public RecipesPage()
		{
			InitializeComponent ();
		    Appearing += RecipesPageAppearing;
        }

	    private async void RecipesPageAppearing(object sender, EventArgs e)
	    {
	        await (BindingContext as RecipesPageViewModel).Appeared();
	    }
    }
}