using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaseRazorPages.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {

            HttpContext.Session.Remove("UserName");
        }
    }
}
