using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace BaseRazorPages.Pages
{
    public class AddUserModel : PageModel
    {

        public string? ErrorMessage { get; set; }

        private readonly UserService _userService;

        public AddUserModel(UserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            Console.WriteLine("Ola do Get");
        }

        public IActionResult OnPost(string name, string password)
        {
            User user = new User();
            user.Name = name;
            user.Password = password;

            if (_userService.GetUserByName(name) != null)
            {
                ErrorMessage = "Usuario ja existe";
                return Page();
            }

            _userService.AddUser(user);

            return RedirectToPage("/Index");
        }


    }
}
