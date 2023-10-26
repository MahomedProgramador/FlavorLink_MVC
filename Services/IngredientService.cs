using Domain.Models;
using Services.Contracts;


namespace Services
{
	public class IngredientService : IIngredientService
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientService(IIngredientRepository ingredientRepository) 
		{
			_ingredientRepository = ingredientRepository;
		}

		public int AddIngredient(Ingredient ingredient)
		{
			return _ingredientRepository.AddIngredient(ingredient);
		}

		public void Delete(IEnumerable<Ingredient> ingredients)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			_ingredientRepository.Delete(id);
		}

		public List<Ingredient> GetAll()
		{
			return _ingredientRepository.GetAll();
		}

		public Ingredient GetById(int id)
		{
			return _ingredientRepository.GetById(id);
		}

		public Ingredient Update(Ingredient ingredient)
		{	
			throw new NotImplementedException();
		}

		public void AddIngredientInRecipe(int id, Ingredient ingredient)
		{
			_ingredientRepository.AddIngredientInRecipe(id, ingredient);
		}
	}
}
