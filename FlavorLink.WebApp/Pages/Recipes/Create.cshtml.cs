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

		[BindProperty]
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
			string name = Convert.ToString(Request.Form["Recipe.Name"]);	
			string prepMethod = Convert.ToString(Request.Form["Recipe.PrepMethod"]);	
			int difficulty = Convert.ToInt32(Request.Form["Recipe.Difficulty"]);	
			int rating = Convert.ToInt32(Request.Form["Recipe.Rating"]);
			string image = Convert.ToString(Request.Form["Recipe.Image"]);

			recipe.Name = name;
			recipe.PrepMethod = prepMethod;
			recipe.Difficulty = difficulty;
			recipe.Rating = rating;

			if (recipe.ImagePath is null)
			{
				recipe.ImagePath = "no-image.jpg";
			}
			else
			{
				recipe.ImagePath = image;	 
			}

			recipe.Ingredients = new List<Ingredient>();

			Recipe = _recipeService.AddRecipe(recipe);
			

			return RedirectToPage("/ingredients/create", new { recipeId = recipe.Id, recipe = Recipe});
		}
	}
}
