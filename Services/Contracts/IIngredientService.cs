using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IIngredientService 
	{
		List<Ingredient> GetAll();
		Ingredient GetById(int id);
		int Add(Ingredient ingredient);
		Ingredient Update(Ingredient ingredient);	
		void Delete(IEnumerable<Ingredient> Ingredients);
		void Delete(int id);
	}
}

