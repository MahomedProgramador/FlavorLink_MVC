using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService _recipeRepository;       
        
        public DeleteModel(IRecipeService recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [BindProperty]
		public Recipe Recipe { get; set; }
		public IActionResult OnGet(int id)
		{
			Recipe = _recipeRepository.GetById(id);
			if (Recipe == null || Recipe.Id == 0)
			{
				return RedirectToPage("/NotFound");
			}
			return Page();
		}

		public void OnPost(int id) 
		{
			
		}
	}
}
