using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthyApp.Views;
using Prism.Unity;
using Xamarin.Forms;

namespace HealthyApp
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
