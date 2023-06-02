using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
		private readonly IRecipeService _recipeService;
		private readonly IIngredientService _ingredientService;

		public Recipe Recipe { get; set; }
		public Ingredient Ingredient { get; set; }

		public DetailsModel(IRecipeService recipeService, IIngredientService ingredientService)
		{
			_recipeService = recipeService;
			_ingredientService = ingredientService;
		}
		public IActionResult OnGet(int id)
        {

			//Ingredient = _ingredientService.GetById(id);
			Recipe = _recipeService.GetById(id);
			if (Recipe == null || Recipe.Id == 0)
			{
				return RedirectToPage("/NotFound");
			}
			return Page();
		}
    }
}
