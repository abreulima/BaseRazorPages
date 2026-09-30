using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace BaseRazorPages.Pages
{
    public class AddIngredientModel : PageModel
    {

        private readonly IngredientsServices _ingredientsServices;

        public AddIngredientModel(IngredientsServices ingredientsServices)
        {
            _ingredientsServices = ingredientsServices;
        }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost(string name)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = name;
            _ingredientsServices.AddIngredient(ingredient);
            return RedirectToPage("/Ingredient");
        }

    }
}
