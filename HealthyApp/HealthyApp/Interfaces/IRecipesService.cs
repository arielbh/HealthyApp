using System.Collections.Generic;
using System.Threading.Tasks;
using HealthyApp.Models;

namespace HealthyApp.Interfaces
{
    public interface IRecipesService
    {
        Task<IEnumerable<Recipe>> GetRecipes();
    }
}