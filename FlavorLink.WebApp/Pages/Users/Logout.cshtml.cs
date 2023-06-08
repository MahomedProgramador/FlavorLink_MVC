using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlavorLink.WebApp.Pages.Users
{
    
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            HttpContext.Session.Remove("Belgas");
            Response.Cookies.Delete("Belgas");
            return RedirectToPage("/Index");
        }
    }
}
