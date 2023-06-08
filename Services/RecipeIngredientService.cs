using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class RecipeIngredientService  : IRecipeIngredientService
	{
		private readonly IRecipeIngredientRepository _recipeIngredientRepository;

		public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
        {
			_recipeIngredientRepository = recipeIngredientRepository;
		}
        public IEnumerable<Ingredient> GetById(int id)
		{
			return _recipeIngredientRepository.GetById(id);
		}

		public IEnumerable<Ingredient> GetByRecipe(Recipe recipe)
		{
			return _recipeIngredientRepository.GetByRecipe(recipe);
		}


	}
}
