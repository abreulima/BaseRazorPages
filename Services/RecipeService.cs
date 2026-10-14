using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Models;

namespace Services
{

    public class RecipeService
    {

        private readonly RecipeRepository _recipeRepository;

        public RecipeService(RecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public Recipe? GetRecipe(int id)
        {
            return _recipeRepository.GetRecipe(id);
        }
    }
}
