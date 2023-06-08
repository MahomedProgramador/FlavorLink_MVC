
using Domain.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using System.Text.Json;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly IRecipeService _recipeService;
		
        public IEnumerable<Recipe> Recipes { get; set; }
		public IndexModel(IRecipeService recipeService)
        {
			_recipeService = recipeService;
		}
        
        public void OnGet()
        {
            Recipes = _recipeService.GetAll();
            GetSessionUser();

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
    }
}
