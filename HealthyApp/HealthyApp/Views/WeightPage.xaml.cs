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
	public partial class WeightPage : ContentPage
	{
		public WeightPage ()
		{
			InitializeComponent ();
            Appearing += WeightPageAppearing;
		}

        private async void WeightPageAppearing(object sender, EventArgs e)
        {
            await (BindingContext as WeightPageViewModel).Appeared();
        }
    }
}