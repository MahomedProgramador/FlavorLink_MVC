using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IIngredientRepository
	{		
		List<Ingredient> GetAll();
		Ingredient GetById(int id);

		int Add(Ingredient ingredient);

		
		void Update(Ingredient ingredient);
		void Delete(int id);

		void Delete(IEnumerable<Ingredient> Ingredients);



	}
}
