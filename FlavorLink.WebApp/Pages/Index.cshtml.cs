using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using System.Collections.Generic;

namespace FlavorLink.WebApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IRecipeService _recipeRepository;
		public IEnumerable<Recipe> Recipes { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }

		public IndexModel(IRecipeService recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}
		public void OnGet()
		{
			Recipes = _recipeRepository.Search(SearchTerm);
		}
	}
}