using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace BaseRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Password { get; set; }


        private readonly UserService _userService;

        public LoginModel(UserService userService)
        {
            _userService = userService;
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

            User? user = _userService.TryLogin(Name, Password);

            if (user == null)
            {
                return (Page());
            }
            else
            {
                Console.WriteLine($"User logged in: {user.Name}");
                HttpContext.Session.SetString("UserName", user.Name);
            }

            return RedirectToPage("/Index");
        }

    }
}
