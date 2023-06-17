using Domain.Models;


namespace Services.Contracts
{	public interface IRecipeRepository 
	{		
		IEnumerable<Recipe> GetAll();
		Recipe GetById(int id);
		Recipe Add(Recipe recipe);
		Recipe Update(Recipe recipe);
		void Delete(int id);
		void Delete(Recipe recipe);
		IEnumerable<Recipe> Search(string searchTerm);
	}
}
