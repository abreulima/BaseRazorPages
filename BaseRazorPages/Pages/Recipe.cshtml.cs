using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Services;
using Models;

namespace BaseRazorPages.Pages
{
    public class RecipeModel : PageModel
    {
    
        private readonly RecipeService _recipeService;

        public Recipe? Recipe { get; set; }

        public RecipeModel(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public void OnGet()
        {

            Recipe = _recipeService.GetRecipe(1);

        }
    }
}
