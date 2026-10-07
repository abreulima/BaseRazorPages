using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace BaseRazorPages.Pages
{
    public class ShowDifficultiesModel : PageModel
    {

        private readonly DifficultyService _difficultyService;

        public ShowDifficultiesModel(DifficultyService difficultyService)
        { 
            _difficultyService = difficultyService;
        }

        public List<Difficulty> difficulties;

        public void OnGet()
        {
            difficulties = _difficultyService.GetAllDifficulties();
        }
    }
}
