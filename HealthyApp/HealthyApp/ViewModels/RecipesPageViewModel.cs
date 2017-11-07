using System.Collections.Generic;
using System.Threading.Tasks;
using HealthyApp.Interfaces;
using HealthyApp.Models;
using Microsoft.Practices.Unity;
using Prism.Mvvm;

namespace HealthyApp.ViewModels
{
    public class RecipesPageViewModel : BindableBase
    {

        public async Task Appeared()
        {
            Recipes = await RecipesService.GetRecipes();

        }

        private IEnumerable<Recipe> _recipes;

        public IEnumerable<Recipe> Recipes
        {
            get { return _recipes; }
            set
            {
                if (value != _recipes)
                {
                    _recipes = value;
                    RaisePropertyChanged();
                }
            }
        }

        [Dependency]
        public IRecipesService RecipesService { get; set; }

    }
}