using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

using Models;

namespace BaseRazorPages.Pages
{
    public class AddUserModel : PageModel
    {

        /*
        [BindProperty]
        [Required]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        */

        private readonly UserService _userService;

        public AddUserModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }
        
        /*
        public void OnPost() 
        { 
            
        }
        */


        public IActionResult OnPost(string name, string password)
        {

            if (!ModelState.IsValid)
                return Page();

            _userService.AddUser(new User
            {
                Id = 0,
                Name = name,
                Password = password,
                IsAdmin = false
            });

            return RedirectToPage("/Index"); // Página atual
        }

    }
}
