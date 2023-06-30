using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.Contracts;

namespace FlavorLink.WebApp.Pages.Ingredients
{
    public class CreateModel : PageModel
    {

        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasurementService _measurementService;

		public IEnumerable<Ingredient> Ingredients { get; set; }
		public IEnumerable<double> IngredientsQuantity { get; set; }
		public IEnumerable<Measurement> Measurements { get; set; }
		public int IngredientId { get; set; }

		public CreateModel(IRecipeIngredientService recipeIngredientService, IIngredientService ingredientService, IMeasurementService measurementService)
		{
			_recipeIngredientService = recipeIngredientService;
			_ingredientService = ingredientService;
			_measurementService = measurementService;
		}
		public void OnGet()
        {
			Ingredients = _ingredientService.GetAll();
			IngredientsQuantity = _recipeIngredientService.GetAllQuantities();
			Measurements = _measurementService.GetAll();			
		}

		public IActionResult OnPost()
		{
			





			throw new NotImplementedException	();
		}
    }
}
