using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using System.Text.Json;

namespace FlavorLink.WebApp.Pages.Users
{
    
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

		public string CurrentPage => "Login";

		[BindProperty]
        public User User { get; set; }

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            GetSessionUser();
        }

        public IActionResult OnPost()
        {
            User u = _userService.Login(User.Username, User.Password);
            if (u != null)
            {
                SetSessionUser(u);
				return RedirectToPage("/Recipes/Index");
			}
            return Page();
           
        }
        private void GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user is not null)
            {
                User u = JsonSerializer.Deserialize<User>(user);
                ViewData["user"] = u;
            }
        }
        private void SetSessionUser(User user)
        {
            string jsonString = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString("user", jsonString);
        }
    }
}
