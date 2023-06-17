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


		public int Add(Ingredient ingredient)
		{
			return _ingredientRepository.Add(ingredient);
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

		
	}
}
