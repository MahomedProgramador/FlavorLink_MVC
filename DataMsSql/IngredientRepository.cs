using Domain.Models;
using Services.Contracts;
using System.ComponentModel;
using System.Data.SqlClient;


namespace DataMsSql
{
	public class IngredientRepository : IIngredientRepository
	{
		


		private string _tableName = "Ingredients";
		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";


		public IEnumerable<Ingredient> UpdateByRecipeId(int id)
		{


			throw new NotImplementedException();
		}

		public int Add(Ingredient ingredient)
		{
			string query = $"INSERT INTO {_tableName} (name, measurement) " +
						   $"VALUES ('{ingredient.Name}', '{ingredient.Measurement}') " +
						   $"SELECT SCOPE_IDENTITY() as 'SCOPE_IDENTITY'";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;


			return ingredient.Id;
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


		public List<Ingredient> GetAll()
		{
			var list = new List<Ingredient>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT * FROM {_tableName}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Ingredient entity = new Ingredient();
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Measurement = Convert.ToString(dr["measurement"]);

				list.Add(entity);
			}
			return list;
		}

		public Ingredient GetById(int id)
		{
			Ingredient entity = new Ingredient();

			string query = $"SELECT * from {_tableName} WHERE id = {id}";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.Read())
			{
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Measurement = Convert.ToString(dr["measurement"]);
			}

			throw new Exception();
		}

		public void Update(Ingredient ingredient)
		{
			throw new NotImplementedException();
		}

		public void Delete(IEnumerable<Ingredient> Ingredients)
		{
			throw new NotImplementedException();
		}


	}
}
