using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;


namespace FlavorLink.WebApp.Pages.Ingredients
{
    public class CreateModel : PageModel
    {        
        private readonly IIngredientService _ingredientService;
        private readonly IMeasurementService _measurementService;
		private readonly IRecipeService _recipeService;
		public List<Ingredient> Ingredients { get; set; }	
		public IEnumerable<Measurement> Measurements { get; set; }
		[BindProperty]
		public Ingredient Ingredient { get; set; }
		public Measurement Measurement { get; set; }
		[BindProperty]
		public Recipe Recipe { get; set; }

		public CreateModel(IIngredientService ingredientService, IMeasurementService measurementService, IRecipeService recipeService)
		{			
			_ingredientService = ingredientService;
			_measurementService = measurementService;
			_recipeService = recipeService;
		}

		public void OnGet([FromRoute]int recipeId)
        {			
			Recipe = _recipeService.GetById(recipeId);
			Ingredients = _ingredientService.GetAll();			
			Measurements = _measurementService.GetAll();			
		}

		public IActionResult OnPost(int recipeId, Ingredient ingredient)
		{
			Recipe = _recipeService.GetById(recipeId);			

			int ingredientId = Convert.ToInt32(Request.Form["Ingredient.Id"]);
			double quantity = Convert.ToDouble(Request.Form["Ingredient.Quantity"]);
			int measurementId = Convert.ToInt32(Request.Form["Ingredient.Measurement.Id"]);	
			recipeId = Recipe.Id;
					

			ingredient.Id = ingredientId;
			ingredient.Quantity = quantity;
			ingredient.Name = _ingredientService.GetById(ingredient.Id).Name;
			Measurement measurement = new Measurement();
			measurement.Id = measurementId;

			Recipe.Id = recipeId;			
			_ingredientService.AddIngredientInRecipe(recipeId, ingredient);

			return RedirectToPage("/Ingredients/Create", new {recipeId = Recipe.Id, recipe = Recipe});
		}
    }
}
