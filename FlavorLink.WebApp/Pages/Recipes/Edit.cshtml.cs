
using Domain.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class EditModel : PageModel
    {
		private readonly IRecipeService _recipeService;
		private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IIngredientService _ingredientService;

		public Recipe Recipe { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public Ingredient Ingredient { get; set; }

        [BindProperty]
         public IFormFile Image { get; set; }

        public EditModel(IRecipeService recipeService, IRecipeIngredientService recipeIngredientService, IIngredientService ingredientService)
        {
			_recipeService = recipeService;
			_recipeIngredientService = recipeIngredientService;
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

		public IActionResult OnPost(Recipe recipe)
		{			
            Recipe = _recipeService.Update(recipe);

            return RedirectToPage("/Recipes/index");
		}

	}
}
