using Domain.Models;
using Services.Contracts;

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
			return _recipeRepository.Add(recipe);
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
			return _recipeRepository.GetById(id);
		}

		public IEnumerable<Recipe> Search(string searchTerm)
		{
			return _recipeRepository.Search(searchTerm);
		}

		public Recipe Update(Recipe recipe)
		{
			throw new NotImplementedException();
		}
	}
}
