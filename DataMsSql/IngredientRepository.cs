using Domain.Models;
using Services;
using Services.Contracts;
using Services.Utils;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;


namespace DataMsSql
{
	public class IngredientRepository : IIngredientRepository
	{			
		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";

		public IEnumerable<Ingredient> UpdateByRecipeId(int id)
		{
			throw new NotImplementedException();
		}

		public void AddIngredientInRecipe(int recipeId, Ingredient ingredient)
		{
			
			string query = @$"INSERT INTO {TableName.Recipes_ingredients} (recipe_id, ingredient_id, measurement_id, quantity) VALUES ({recipeId},{ingredient.Id},{ingredient.Measurement.Id},{ingredient.Quantity})";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			int id = Convert.ToInt32(cmd.ExecuteScalar());
			ingredient.Id = id;			
		}

		public void Delete(int id)
		{
			
			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"DELETE FROM {TableName.Ingredients} WHERE id = {id}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			cmd.ExecuteNonQuery();
		}


		public List<Ingredient> GetAll()
		{
			var list = new List<Ingredient>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT * FROM {TableName.Ingredients}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Ingredient entity = new Ingredient();
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Measurement = new Measurement();					

				list.Add(entity);
			}
			return list;
		}

		public Ingredient GetById(int id)
		{		
			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT * FROM {TableName.Ingredients} WHERE id = {id};";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();
			Ingredient entity = new Ingredient();
			while (dr.Read())
			{
				
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Measurement = new Measurement();

				return entity;
			}
			return entity;
		}

		public void Update(Ingredient ingredient)
		{
			throw new NotImplementedException();
		}

		public int AddIngredient(Ingredient ingredient)
		{
			throw new NotImplementedException();
		}

		public Ingredient GetFullById(int id)
		{
			//fazer aqui o inner join e mostrar o measurement
			Ingredient entity = new Ingredient();

			//string query = $"SELECT * from {_tables[0]} WHERE id = {id}";

			string query = $"SELECT i.name, quantity, m.unit FROM {TableName.Recipes_ingredients} as ri " +
							$"INNER JOIN {TableName.Ingredients} as i " +
							"ON ri.ingredient_id = i.id " +
							$"INNER JOIN {TableName.Measurement} as m " +
							"ON ri.measurement_id = m.id " +
							$"WHERE i.id = {id};";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.Read())
			{
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);

				entity.Measurement = (Measurement)(dr["unit"]);
			}

			throw new Exception();
		}
	}
}
