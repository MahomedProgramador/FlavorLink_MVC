using Domain.Models;

namespace Services.Contracts
{
	public interface IRecipeService 
	{
		IEnumerable<Recipe> GetAll();
		Recipe GetById(int id);
		Recipe AddRecipe(Recipe recipe);
		Recipe Update(Recipe recipe);
		void Delete(int id);
		void Delete(Recipe recipe);
		IEnumerable<Recipe> Search(string searchTerm);
	}
}
