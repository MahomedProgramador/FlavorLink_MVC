using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
		private readonly IRecipeService _recipeService;
		private readonly IRecipeIngredientService _recipeIngredientService;
		
		

		public Recipe Recipe { get; set; }
		public IEnumerable<Measurement> Measurement { get; set; }

		public IEnumerable<Ingredient> Ingredients { get; set; }

		public DetailsModel(IRecipeService recipeService, IRecipeIngredientService recipeIngredientService)
		{
			_recipeService = recipeService;
			_recipeIngredientService = recipeIngredientService;
			
		}
		public IActionResult OnGet(int id)
        {
			
			Ingredients = _recipeIngredientService.GetById(id); //Devia tar no recipeService e ter lá um getByIdWithIngredients.
			Recipe = _recipeService.GetById(id);

			if (Recipe == null || Recipe.Id == 0)
			{
				return RedirectToPage("/NotFound");
			}
			return Page();
		}
    }
}

