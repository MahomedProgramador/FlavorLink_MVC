﻿using Domain.Models;
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
		int AddIngredient(Ingredient ingredient);
		Ingredient Update(Ingredient ingredient);			
		void Delete(int id);
		void AddIngredientInRecipe(int id, Ingredient ingredient);
	}
}

