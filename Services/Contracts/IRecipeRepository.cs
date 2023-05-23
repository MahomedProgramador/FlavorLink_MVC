using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IRecipeRepository 
	{
		List<Recipe> GetAll ();
		Recipe GetById(int id);
		Recipe Add(Recipe recipe);
		Recipe Update(Recipe recipe);
		void Delete(int id);
		void Delete(Recipe recipe);
	}
}
