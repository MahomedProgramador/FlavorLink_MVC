using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataMsSql
{
	public class RecipeIngredientRepository : IRecipeIngredientRepository
	{

		private string[] _tableNames = { "recipes_ingredients", "ingredients", "Recipes" };

		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";

		private readonly IIngredientRepository _ingredientRepository;

		private readonly IRecipeRepository _recipeRepository;

        public RecipeIngredientRepository(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository)
        {
			_ingredientRepository = ingredientRepository;
			_recipeRepository = recipeRepository;
		}      

        public IEnumerable<Ingredient> GetById(int id)
		{	
			var ingredientList = new List<Ingredient>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT i.name, measurement " +
						   $"FROM {_tableNames[0]} as ri " +
						   $"INNER JOIN {_tableNames[1]} as i " +
						   $"ON ri.ingredient_id = i.id " +
						   $"INNER JOIN {_tableNames[2]} as r " +
						   $"ON r.id = ri.recipe_id " +
						   $"WHERE r.id = {id}; ";

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Ingredient entity = new Ingredient();				
				entity.Name = Convert.ToString(dr["name"]);
				entity.Measurement = Convert.ToString(dr["measurement"]); 		

				ingredientList.Add(entity);
			}
			return ingredientList;
		}

		public IEnumerable<Ingredient> GetByRecipe(Recipe recipe)
		{
			var ingredientList = new List<Ingredient>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT i.name, measurement " +
						   $"FROM {_tableNames[0]} as ri " +
						   $"INNER JOIN {_tableNames[1]} as i " +
						   $"ON ri.ingredient_id = i.id " +
						   $"INNER JOIN {_tableNames[2]} as r " +
						   $"ON r.id = ri.recipe_id " +
						   $"WHERE r.id = {recipe.Id}; ";

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Ingredient entity = new Ingredient();
				entity.Name = Convert.ToString(dr["name"]);
				entity.Measurement = Convert.ToString(dr["measurement"]);

				ingredientList.Add(entity);
			}
			return ingredientList;
		}
	}
}
