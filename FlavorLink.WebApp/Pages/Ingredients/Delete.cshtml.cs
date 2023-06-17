using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IRecipeService _recipeService;
        private readonly IIngredientService _ingredientService;

        public Ingredient Ingredient { get; set; }

        public DeleteModel(IRecipeIngredientService recipeIngredientService, IRecipeService recipeService, IIngredientService ingredientService)
        {
            _recipeIngredientService = recipeIngredientService;
            _recipeService = recipeService;
            _ingredientService = ingredientService;
        }

        public IActionResult OnGet(int id)
        {

			Ingredients = _recipeIngredientService.GetById(id);
			Recipe = _recipeService.GetById(id);

			

			if (Recipe == null || Ingredients == null)
			{
				return RedirectToPage("/NotFound");
			}

			return Page();
		}
    }
}
