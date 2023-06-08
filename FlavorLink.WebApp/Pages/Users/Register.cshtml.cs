using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Users
{
	public class RegisterModel : PageModel
	{
		private readonly IUserService _userService;

		[BindProperty]
		public string Username { get; set; }
		[BindProperty]
		public string Password { get; set; }

		public RegisterModel(IUserService userService)
		{
			_userService = userService;
		}


		public void OnGet()
		{

		}

		public IActionResult OnPost()
		{
			if (Username is null || Password is null)
			{
				return RedirectToPage("/NotFound");
			}

			bool userExists = _userService.UserExists(Username);

			if (userExists)
			{
				return RedirectToPage("/Users/UserExists");
			}

			User user = _userService.Register(Username, Password);

			if (user is null)
			{				
				return RedirectToPage("/NotFound");
			}

			return RedirectToPage("/Recipes/Index");
		}
	}
}
