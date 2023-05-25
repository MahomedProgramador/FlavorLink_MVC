
using Domain.Models;
using Services.Contracts;

namespace InMemory
{
	public class InMemoryRepository 
	{
		private List<Recipe> _recipesList;


		public InMemoryRepository() 
		{
			_recipesList = new List<Recipe>()
			{
				new Recipe(){ Id = 1, Name = "Bacalhau à Brás", PrepMethod= "Escamar o bacalhau e cozinhar", ImagePath = "bacalhau-a-bras.jpg" },
				new Recipe(){ Id = 2, Name = "Bife à Cavalo", PrepMethod= "Cozinhar o bife e estrelar o ovo", ImagePath = "bife-a-cavalo.jpg"},
				new Recipe(){ Id = 3, Name = "Pizza", PrepMethod= "Amassar bem", ImagePath = "pizza.jpg"}
			};
		}

		public Recipe Add(Recipe recipe)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Delete(Recipe recipe)
		{
			throw new NotImplementedException();
		}

		public List<Recipe> GetAll()
		{
			throw new NotImplementedException();
		}

		public Recipe GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Recipe Search(string searchTerm)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Recipe> Update(Recipe recipe)
		{
			throw new NotImplementedException();
		}
	}

}
