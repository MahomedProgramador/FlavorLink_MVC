using Domain.Models;
using Services.Contracts;
using System.Data.SqlClient;
using System.Xml;

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

		private void RemoveRelationship(int recipeId)
		{
			var ingredientList = new List<int>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			string query = $"Select Ingredient_id from recipes_ingredients where recipe_id = {recipeId}";
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				ingredientList.Add(Convert.ToInt32(dr["ingredient_id"]));
			}

			query = $"DELETE FROM recipes_ingredients WHERE recipe_id = {recipeId}";
			cmd.CommandText = query;
			conn.Close();
			conn.Open();
			cmd.ExecuteNonQuery();

			foreach (int ingredientId in ingredientList)
			{
				_ingredientRepository.Delete(ingredientId);
			}			

			conn.Close();
		}

		public void Delete(int id)
		{
			RemoveRelationship(id);

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

				//A tabela já não tem o campo do ingredient, está a ir para outro lado
				//Ingredient i = new Ingredient();
				//i.Id = Convert.ToInt32(dr["ingredients"]);
				//entity.Ingredients.Add(i);		

				if (!Convert.IsDBNull(dr["difficulty"]))
					entity.Difficulty = Convert.ToInt32(dr["difficulty"]);
				else
					entity.Difficulty = null; // Nullable int

				if (!Convert.IsDBNull(dr["rating"]))
					entity.Rating = Convert.ToInt32(dr["rating"]);
				else
					entity.Rating = null; // Nullable int

				entity.ImagePath = Convert.ToString(dr["image_path"]);
				
				list.Add(entity);
			}
			return list;
		}
		public Recipe GetById(int id)
		{
			string query = $"SELECT * from {_tableName} WHERE id = {id}";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();
			
			if (dr.Read())
			{				
				Recipe entity = new Recipe();
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Ingredients = new List<Ingredient>();
				entity.PrepMethod = Convert.ToString(dr["prep_method"]);

				if (!Convert.IsDBNull(dr["difficulty"]))
					entity.Difficulty = Convert.ToInt32(dr["difficulty"]);
				else
					entity.Difficulty = null; // Nullable int
				if (!Convert.IsDBNull(dr["rating"]))
					entity.Rating = Convert.ToInt32(dr["rating"]);
				else
					entity.Rating = null; // Nullable int

				entity.ImagePath = Convert.ToString(dr["image_path"]);				
				return entity;
			}
			throw new KeyNotFoundException($"Recipe Id {id} Not Found"); //nao queria mandar a pagina abaixo. 
		}
		public Recipe Update(Recipe entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Recipe> Search(string searchTerm)
		{
			var list = new List<Recipe>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT * FROM {_tableName} WHERE UPPER(Name) LIKE '%{searchTerm}%' OR name LIKE '%{searchTerm}%'";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Recipe entity = new Recipe();
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);

				entity.Ingredients = new List<Ingredient>();
				if (dr["prep_method"] is DBNull)
				{
					entity.PrepMethod = "Não tem descrição";
				}
				else
				{
					entity.PrepMethod = Convert.ToString(dr["prep_method"]);					
				}

				if (dr["difficulty"] is DBNull)
				{
					entity.Difficulty = 0;
				}
				else
				{
					entity.Difficulty = Convert.ToInt32(dr["difficulty"]);
				}

				if (dr["rating"] is DBNull)
				{
					entity.Rating = 5;
				}
				else
				{
					entity.Rating = Convert.ToInt32(dr["rating"]);
				}
				
				entity.ImagePath = Convert.ToString(dr["image_path"]);

				list.Add(entity);
			}
			return list;			
		}
	}
}
