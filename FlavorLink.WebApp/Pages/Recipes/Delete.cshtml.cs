using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService _recipeService;       
        private readonly IRecipeIngredientService _recipeIngredientService;    
        private readonly IIngredientService _ingredientService;    
		
		public IEnumerable<Ingredient> Ingredients { get; set; }
        
        public DeleteModel(IRecipeService recipeRepository, IRecipeIngredientService recipeIngredientService, IIngredientService ingredientService)
        {
            _recipeService = recipeRepository;
			_recipeIngredientService = recipeIngredientService;
			_ingredientService = ingredientService;
        }

        [BindProperty]
		public Recipe Recipe { get; set; }
		public IActionResult OnGet(int id)
		{
			Recipe = _recipeService.GetById(id);			

			if (Recipe == null || Recipe.Id == 0)
			{
				return RedirectToPage("/NotFound");
			}

			var recipeIngredients = _recipeIngredientService.GetById(id);
			var ingredientIds = recipeIngredients.Select(ri => ri.Id).ToList();
			Ingredients = ingredientIds
				.Select(ingredientId => _ingredientService.GetById(ingredientId))
				.Where(ingredient => ingredient != null)
				.ToList();
	
			return Page();
		}

		public IActionResult OnPost(int id) 
		{
			_recipeService.Delete(id);

			return RedirectToPage("/Recipes/Index");
		}
	}
}
