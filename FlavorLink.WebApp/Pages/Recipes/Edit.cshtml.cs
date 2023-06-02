using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class EditModel : PageModel
    {
		private readonly IRecipeService _recipeService;

        public Recipe Recipe { get; set; }

        public Ingredient Ingredient { get; set; }

        [BindProperty]
         public IFormFile Image { get; set; }

        public EditModel(IRecipeService recipeService)
        {
			_recipeService = recipeService;
		}

        public IActionResult OnGet(int id)
        {    
            Recipe = _recipeService.GetById(id);

            if (Recipe == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

		public IActionResult OnPost(Recipe recipe)
		{
            Recipe = _recipeService.Update(recipe);

			return RedirectToPage("/index");
		}

	}
}
