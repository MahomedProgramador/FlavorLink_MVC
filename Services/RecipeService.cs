using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IRecipeRepository _recipeRepository;

		public RecipeService(IRecipeRepository recipeRepository)
        {
			_recipeRepository = recipeRepository;
		}

        public Recipe Add(Recipe recipe)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			_recipeRepository.Delete(id);
		}

		public void Delete(Recipe recipe)
		{
			_recipeRepository.Delete(recipe);
		}

		public List<Recipe> GetAll()
		{
			return _recipeRepository.GetAll();
		}

		public Recipe GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Recipe Update(Recipe recipe)
		{
			throw new NotImplementedException();
		}
	}
}
