
using Domain.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

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
			

		}
    }
}
