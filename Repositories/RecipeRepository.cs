using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories
{
    public class RecipeRepository
    {

        public List<Recipe> recipes = new List<Recipe>
        {
            new Recipe
            {
                Name = "Pastel de Nata",
                Ingredients =
                {
                    new Ingredient
                    {
                        Id = 1,
                        Name = "Egg"
                    }
                }
            }
        };
    }
}
