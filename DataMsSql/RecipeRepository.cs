

using Domain.Models;
using Services.Contracts;
using System.Data.SqlClient;
using System.Transactions;

namespace DataMsSql
{
	public class RecipeRepository : IRecipeRepository
	{
		private string _tableName = "Recipes";
		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";

		private readonly IIngredientRepository _ingredientRepository;

        public RecipeRepository(IIngredientRepository ingredientRepository)
        {
			_ingredientRepository = ingredientRepository;
        }

        public Recipe Add(Recipe entity)
		{			

			string query = $"INSERT INTO {_tableName} (name, prep_method, difficulty, rating, image_path) " +
						   $"VALUES ('{entity.Name}', '{entity.PrepMethod}', {entity.Difficulty}, {entity.Rating}, '{entity.ImagePath}') " +
						   $"SELECT SCOPE_IDENTITY() as 'SCOPE_IDENTITY'";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			int id = Convert.ToInt32(cmd.ExecuteScalar());
			entity.Id = id;

			foreach (Ingredient ingredient in entity.Ingredients)
			{
				ingredient.Id = _ingredientRepository.Add(ingredient);

				CreateRelationship(entity.Id, ingredient.Id);
			}

			return entity;
		}

		private void CreateRelationship(int recipeId, int ingredientId)
		{
			string query = $"INSERT INTO recipes_ingredients (recipe_id, ingredient_id) " +
					   $"VALUES ({recipeId}, {ingredientId}); ";
					   
			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			cmd.ExecuteNonQuery();			
		}

		public void Delete(int id)
		{
			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"DELETE FROM {_tableName} WHERE id = {id}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			cmd.ExecuteNonQuery();
		}

		public void Delete(Recipe entity)
		{
			Delete(entity.Id);
		}

		public List<Recipe> GetAll()
		{
			var list = new List<Recipe>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT * FROM {_tableName}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Recipe entity = new Recipe();
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Ingredients= new List<Ingredient>();

				Ingredient i = new Ingredient();
				i.Id = Convert.ToInt32(dr["ingredients"]);

				entity.Ingredients.Add(i);
				entity.PrepMethod = Convert.ToString(dr["prep_method"]);
				entity.Difficulty = Convert.ToInt32(dr["difficulty"]);
				entity.Rating = Convert.ToInt32(dr["rating"]);
				entity.ImagePath = Convert.ToString(dr["image_path"]);
				
				list.Add(entity);
			}
			return list;
		}

		public Recipe GetById(int id)
		{
			Recipe entity = new Recipe();

			string query = $"SELECT * from {_tableName} WHERE id = {id}";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{				
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Ingredients = new List<Ingredient>();

				Ingredient i = new Ingredient();
				i.Id = Convert.ToInt32(dr["ingredients"]);
				entity.Ingredients.Add(i);

				entity.PrepMethod = Convert.ToString(dr["prep_method"]);
				entity.Difficulty = Convert.ToInt32(dr["difficulty"]);
				entity.Rating = Convert.ToInt32(dr["rating"]);
				entity.ImagePath = Convert.ToString(dr["image_path"]);				
			}
			return entity;
		}

		public Recipe Update(Recipe entity)
		{
			throw new NotImplementedException();
		}
	}
}
