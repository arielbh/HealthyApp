using System.Collections.Generic;
using System.Threading.Tasks;
using HealthyApp.Interfaces;
using HealthyApp.Models;

namespace HealthyApp.Services
{
    public class RecipesService : IRecipesService
    {
        public Task<IEnumerable<Recipe>> GetRecipes()
        {
            return Task.FromResult(new[]
            {
                new Recipe()
                {
                    Name = "Black Beans Burger",
                    Description = "Vegan alternative for the delicious burger",
                    ImageUrl = "http://food.fnr.sndimg.com/content/dam/images/food/fullset/2015/7/28/0/FNM_090115-Black-Bean-Burgers-Recipe_s4x3.jpg.rend.hgtvcom.406.305.suffix/1438116916324.jpeg",
                },
                new Recipe()
                {
                    Name = "Beet Root Raw Hummus",
                    Description = "The beloved Hummus in a pink version.",
                    ImageUrl = "https://www.ndtv.com/cooks/images/beetroot-hummus.jpg"
                },
                new Recipe()
                {
                    Name = "Chocolate Mousse",
                    Description = "A vegan, healthy version to the ultimate treat",
                    ImageUrl = "http://1.bp.blogspot.com/-lBPUCBe3YLs/UFZGta5oqiI/AAAAAAAABHo/BSY-BSsxVIE/s1600/Chocolate+Mousse.JPG"

                },
                new Recipe()
                {
                    Name = "Raw Japanese Dumplings",
                    Description = "Delicious Dumplings served with Seasme souce",
                    ImageUrl = "https://i.pinimg.com/236x/ab/3d/da/ab3ddabd1af25429bb5716fcccc03af9--thai-spring-rolls-fresh-spring-rolls-vegetarian.jpg"
                }


            } as IEnumerable<Recipe>);

        }
    }

}