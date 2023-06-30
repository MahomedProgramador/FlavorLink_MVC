using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class CreateModel : PageModel
    {
		private readonly IRecipeService _recipeService;
		private readonly IRecipeIngredientService _recipeIngredientService;
		private readonly IIngredientService _ingredientService;
		private readonly IMeasurementService _measurementService;

		public Recipe Recipe { get; set; }	


		[BindProperty]
		public IFormFile Image { get; set; }
	


		public CreateModel(IRecipeService recipeService)
		{
			_recipeService = recipeService;

		}
		public void OnGet()
        {			
	

		}

		public IActionResult OnPost(Recipe recipe)
		{
			
			Recipe = _recipeService.AddRecipe(recipe);
			return RedirectToPage("/Recipes/Details/" + recipe.Id);
		}
	}
}
