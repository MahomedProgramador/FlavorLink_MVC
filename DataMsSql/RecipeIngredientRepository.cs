using Domain.Models;
using Services.Contracts;
using Services.Utils;
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

		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";

		private readonly IIngredientRepository _ingredientRepository;

		private readonly IRecipeRepository _recipeRepository;

		private readonly IMeasurementRepository _measurementRepository;

        public RecipeIngredientRepository(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository, IMeasurementRepository measurementRepository)
        {
			_ingredientRepository = ingredientRepository;
			_recipeRepository = recipeRepository;
			_measurementRepository = measurementRepository;
		}      

        public IEnumerable<Ingredient> GetById(int id) //GetIngredientById
		 {	
			var ingredientList = new List<Ingredient>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();
			
			string query = $"SELECT i.name, ri.quantity, m.unit " +
						   $"FROM {TableName.Recipes_ingredients} as ri " +
						   $"INNER JOIN {TableName.Ingredients} as i " +
						   $"ON ri.ingredient_id = i.id " +
						   $"INNER JOIN {TableName.Recipes} as r " +
						   $"ON r.id = ri.recipe_id " +
						   $"INNER JOIN {TableName.Measurement} as m " +
						   $"ON m.id = ri.measurement_id " +
						   $"WHERE r.id = {id}; ";

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				
				Ingredient ingredient = new Ingredient();				
				ingredient.Name = Convert.ToString(dr["name"]);
				ingredient.Quantity = Convert.ToDouble(dr["quantity"]);
				Measurement measurement = new Measurement();
				measurement.Unit = Convert.ToString(dr["unit"]);
				ingredient.Measurement = measurement;

				ingredientList.Add(ingredient);
			}
			return ingredientList;
		}

		public IEnumerable<Ingredient> GetByRecipe(Recipe recipe)
		{
			var ingredientList = new List<Ingredient>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT i.name, measurement " +
						   $"FROM {TableName.Recipes_ingredients} as ri " +
						   $"INNER JOIN {TableName.Ingredients} as i " +
						   $"ON ri.ingredient_id = i.id " +
						   $"INNER JOIN {TableName.Recipes} as r " +
						   $"ON r.id = ri.recipe_id " +
							$"INNER JOIN {TableName.Measurement} as m " +
						   $"ON m.id = ri.measurement_id " +
						   $"WHERE r.id = {recipe.Id}; ";

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Ingredient entity = new Ingredient();
				entity.Name = Convert.ToString(dr["name"]);
				entity.Measurement = new Measurement();

				ingredientList.Add(entity);
			}
			return ingredientList;
		}

		public IEnumerable<double> GetAllQuantities()
		{
			var list = new List<double>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT quantity FROM {TableName.Recipes_ingredients}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Ingredient entity = new Ingredient();
				entity.Quantity = Convert.ToDouble(dr["quantity"]);
				

				list.Add(entity.Quantity);
			}
			return list;
		}

		//TODO fazer um create ingredient.
	}
}
