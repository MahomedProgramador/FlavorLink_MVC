using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService _recipeService;       
        
        public DeleteModel(IRecipeService recipeRepository)
        {
            _recipeService = recipeRepository;
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
			return Page();
		}

		public IActionResult OnPost(int id) 
		{
			_recipeService.Delete(id);

			return RedirectToPage("/Recipes/Index");
		}
	}
}
