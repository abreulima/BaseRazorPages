using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace BaseRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;
        public List<User> Users { get; set; }

        public IndexModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            Users = _userService.GetAllUsers();
        }
    }
}
