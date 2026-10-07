using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Models;
using Services;

namespace BaseRazorPages.Pages
{
    public class AddDifficultyModel : PageModel
    {

        [BindProperty]
        [Required]
        public string Name { get; set; }

        private readonly DifficultyService _difficultyService;
        public AddDifficultyModel(DifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Difficulty difficulty = new Difficulty();
            difficulty.Name = Name;

            _difficultyService.AddDifficulty(difficulty);

            return RedirectToPage("/Index");

        }
    }
}
