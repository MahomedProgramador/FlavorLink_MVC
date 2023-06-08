using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IRecipeIngredientRepository
	{
		public IEnumerable<Ingredient> GetById(int id);

		public IEnumerable<Ingredient> GetByRecipe(Recipe recipe);
	}
}
