using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthyApp.Interfaces;
using HealthyApp.Services;
using HealthyApp.Views;
using Microsoft.Practices.Unity;
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
            Container.RegisterType<IRecipesService, RecipesService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWeightAccessService, WeightAccessService>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
