using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
		private readonly IRecipeService _recipeRepository;
		public Recipe Recipe { get; set; }

		public DetailsModel(IRecipeService recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}
		public IActionResult OnGet(int id)
        {
			Recipe = _recipeRepository.GetById(id);
			if (Recipe == null || Recipe.Id == 0)
			{
				return RedirectToPage("/NotFound");
			}
			return Page();
		}
    }
}
